using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CombatUIManager : MonoBehaviour
{
    public GameObject SwitchingPanel;
    public GameObject ItemPanel;

    public Image SwordImage;
    public Sprite[] Swords;

    public TextMeshProUGUI HealthTxt;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealthUI();
        ChangeSwordSprite();
        Equipment.Instance.AssignUI(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchButton()
    {
        if (SwitchingPanel.activeSelf == false)
        {
            SwitchingPanel.SetActive(true);

            if (!Equipment.Instance.FireUnlocked)
            {
                SwitchingPanel.transform.Find("FireButton").gameObject.SetActive(false);
            }
            else
            {
                SwitchingPanel.transform.Find("FireButton").gameObject.SetActive(true);
            }

            if (!Equipment.Instance.WaterUnlocked)
            {
                SwitchingPanel.transform.Find("WaterButton").gameObject.SetActive(false);
            }
            else
            {
                SwitchingPanel.transform.Find("WaterButton").gameObject.SetActive(true);
            }

            if (!Equipment.Instance.EarthUnlocked)
            {
                SwitchingPanel.transform.Find("EarthButton").gameObject.SetActive(false);
            }
            else
            {
                SwitchingPanel.transform.Find("EarthButton").gameObject.SetActive(true);
            }

            if (!Equipment.Instance.ThunderUnlocked)
            {
                SwitchingPanel.transform.Find("ThunderButton").gameObject.SetActive(false);
            }
            else
            {
                SwitchingPanel.transform.Find("ThunderButton").gameObject.SetActive(true);
            }
        }
        else
        {
            SwitchingPanel.SetActive(false);
        }
    }

    public void ItemButton()
    {
        if (ItemPanel.activeSelf == false)
        {
            ItemPanel.SetActive(true);

            if (Equipment.Instance.PotionNum == 0)
            {
                ItemPanel.transform.Find("PotButton").gameObject.SetActive(false);
            }
            else
            {
                ItemPanel.transform.Find("PotButton").gameObject.SetActive(true);
                ItemPanel.transform.Find("PotButton").GetChild(0).GetComponent<TextMeshProUGUI>().text = "Potion: " + Equipment.Instance.PotionNum;
            }

            if (Equipment.Instance.SupPotionNum == 0)
            {
                ItemPanel.transform.Find("SuperPotButton").gameObject.SetActive(false);


            }
            else
            {
                ItemPanel.transform.Find("SuperPotButton").GetChild(0).GetComponent<TextMeshProUGUI>().text = "Super Potion: " + Equipment.Instance.SupPotionNum;
                ItemPanel.transform.Find("SuperPotButton").gameObject.SetActive(true);
            }
        }
        else
        {
            ItemPanel.SetActive(false);
        }
    }

    public void QuitButton()
    {
        SavingManager.Instance.SaveGame();
        SceneLoader.Instance.Load("MainMenu");
    }

    public void UpdateHealthUI()
    {
        HealthTxt.text = "HP: " + Equipment.Instance.Health + "/" + Equipment.Instance.GetMaxHealth();
    }

    public void FireButton()
    {
        if (Equipment.Instance.CurrentSwordElement == GlobalEnums.Elements.FIRE)
        {
            Equipment.Instance.ChangeSwordElement(GlobalEnums.Elements.NORMAL);
        }
        else
        {
            Equipment.Instance.ChangeSwordElement(GlobalEnums.Elements.FIRE);
        }
        ChangeSwordSprite();
    }

    public void WaterButton()
    {
        if (Equipment.Instance.CurrentSwordElement == GlobalEnums.Elements.WATER)
        {
            Equipment.Instance.ChangeSwordElement(GlobalEnums.Elements.NORMAL);
        }
        else
        {
            Equipment.Instance.ChangeSwordElement(GlobalEnums.Elements.WATER);
        }
        ChangeSwordSprite();
    }

    public void EarthButton()
    {
        if (Equipment.Instance.CurrentSwordElement == GlobalEnums.Elements.EARTH)
        {
            Equipment.Instance.ChangeSwordElement(GlobalEnums.Elements.NORMAL);
        }
        else
        {
            Equipment.Instance.ChangeSwordElement(GlobalEnums.Elements.EARTH);
        }
        ChangeSwordSprite();
    }

    public void ThunderButton()
    {
        if (Equipment.Instance.CurrentSwordElement == GlobalEnums.Elements.THUNDER)
        {
            Equipment.Instance.ChangeSwordElement(GlobalEnums.Elements.NORMAL);
        }
        else
        {
            Equipment.Instance.ChangeSwordElement(GlobalEnums.Elements.THUNDER);
        }
        ChangeSwordSprite();
    }

    void ChangeSwordSprite()
    {
        switch (Equipment.Instance.CurrentSwordElement)
        {
            case GlobalEnums.Elements.FIRE:
                SwordImage.sprite = Swords[0];
                break;
            case GlobalEnums.Elements.WATER:
                SwordImage.sprite = Swords[1];
                break;
            case GlobalEnums.Elements.EARTH:
                SwordImage.sprite = Swords[2];
                break;
            case GlobalEnums.Elements.THUNDER:
                SwordImage.sprite = Swords[3];
                break;
            case GlobalEnums.Elements.NORMAL:
                SwordImage.sprite = Swords[4];
                break;
            default:
                Debug.Log("ChangeSwordSprite Switch Error");
                break;
        }
    }

    public void PotButton()
    {
        Equipment.Instance.PotionNum--;
        Equipment.Instance.Heal(25);
    }

    public void SuperPotButton()
    {
        Equipment.Instance.SupPotionNum--;
        Equipment.Instance.Heal(75);
    }
}
