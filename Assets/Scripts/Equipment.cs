using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : Singleton<Equipment>
{
    public GlobalEnums.Elements CurrentSwordElement;

    public int Health;
    private int _maxHealth = 200;

    public bool FireUnlocked;
    public bool WaterUnlocked;
    public bool EarthUnlocked;
    public bool ThunderUnlocked;

    public int PotionNum;
    public int SupPotionNum;

    private CombatUIManager UIManager;

    // Start is called before the first frame update
    void Awake()
    {
        Health = _maxHealth;
        CurrentSwordElement = GlobalEnums.Elements.NORMAL;

        PotionNum = 5;
        SupPotionNum = 0;
    }

    public void LoadEquipment(EquipmentData data)
    {
        if (data.Health < 0)
        {
            Health = _maxHealth;
        }
        else
        {
            Health = data.Health;
        }

        FireUnlocked = data.FireUnlocked;
        WaterUnlocked = data.WaterUnlocked;
        EarthUnlocked = data.EarthUnlocked;
        ThunderUnlocked = data.ThunderUnlocked;

        PotionNum = data.PotionNum;
        SupPotionNum = data.SupPotionNum;
    }

    public bool UnlockElement(GlobalEnums.Elements newSword)
    {
        switch (newSword)
        {
            case GlobalEnums.Elements.FIRE:
                if (!FireUnlocked)
                {
                    FireUnlocked = true;
                    return true;
                }
                break;
            case GlobalEnums.Elements.WATER:
                if (!WaterUnlocked)
                {
                    WaterUnlocked = true;
                    return true;
                }
                break;
            case GlobalEnums.Elements.EARTH:
                if (!EarthUnlocked)
                {
                    EarthUnlocked = true;
                    return true;
                }
                break;
            case GlobalEnums.Elements.THUNDER:
                if (!ThunderUnlocked)
                {
                    ThunderUnlocked = true;
                    return true;
                }
                break;
            case GlobalEnums.Elements.NORMAL:
                break;
            default:
                break;
        }
        return false;
    }

    public void ChangeSwordElement(GlobalEnums.Elements newElement)
    {
        CurrentSwordElement = newElement;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        UIManager.UpdateHealthUI();
        if (Health <= 0)
        {
            Application.Quit();
        }
    }

    public void Heal(int value)
    {
        Health += value;

        if (Health > _maxHealth)
        {
            Health = _maxHealth;
        }

        UIManager.UpdateHealthUI();
    }

    public int GetMaxHealth()
    {
        return _maxHealth;
    }

    public void AssignUI(CombatUIManager newManager)
    {
        UIManager = newManager;
    }
}
