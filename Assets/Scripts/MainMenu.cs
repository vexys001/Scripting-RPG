using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        EquipmentData newData = new EquipmentData(-1,false,false,false,false,5,0);
        Equipment.Instance.LoadEquipment(newData);

        QuestData newQuests = new QuestData(0,0);
        Quest.Instance.LoadQuest(newQuests);

        SceneLoader.Instance.Load("MainRoom");
    }

    public void LoadGame()
    {
        SavingManager.Instance.LoadSave();
        SceneLoader.Instance.Load("MainRoom");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
