using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingManager : Singleton<SavingManager>
{
    public void SaveGame()
    {
        Equipment equip = Equipment.Instance;
        EquipmentData equipData = new EquipmentData(equip.Health, 
            equip.FireUnlocked, equip.WaterUnlocked, equip.EarthUnlocked, equip.ThunderUnlocked, 
            equip.PotionNum, equip.SupPotionNum);

        string equipment = JsonUtility.ToJson(equipData);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/EquipmentData.json", equipment);

        Quest quest = Quest.Instance;
        QuestData questData = new QuestData(quest.Step, quest.QuestCompleted);

        string questPro = JsonUtility.ToJson(questData);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/QuestData.json", questPro);
    }

    public void LoadSave()
    {
        string equipSaveFile;
        string questSaveFile;

        equipSaveFile = Application.persistentDataPath + "/EquipmentData.json";
        questSaveFile = Application.persistentDataPath + "/QuestData.json";

        if (System.IO.File.Exists(equipSaveFile))
        {
            string equipContent = System.IO.File.ReadAllText(equipSaveFile);

            EquipmentData equipData = JsonUtility.FromJson<EquipmentData>(equipContent);

            Equipment.Instance.LoadEquipment(equipData);
        }

        if (System.IO.File.Exists(questSaveFile))
        {
            string questContent = System.IO.File.ReadAllText(questSaveFile);

            QuestData questData = JsonUtility.FromJson<QuestData>(questContent);

            Quest.Instance.LoadQuest(questData);
        }
    }
}

[System.Serializable]
public class EquipmentData
{
    public int Health;

    public bool FireUnlocked;
    public bool WaterUnlocked;
    public bool EarthUnlocked;
    public bool ThunderUnlocked;

    public int PotionNum;
    public int SupPotionNum;
    public EquipmentData(int health, 
        bool fireUnl, bool waterUnl, bool earthUnl, bool thunderUnl, 
        int potNum, int supPotNum)
    {
        Health = health;

        FireUnlocked = fireUnl;
        WaterUnlocked = waterUnl;
        EarthUnlocked = earthUnl;
        ThunderUnlocked = thunderUnl;

        PotionNum = potNum;
        SupPotionNum = supPotNum;
    }
}

[System.Serializable]
public class QuestData
{
    public int Step;

    public int QuestCompleted;
    public QuestData(int step, int completed)
    {
        Step = step;
        QuestCompleted = completed;
    }
}
