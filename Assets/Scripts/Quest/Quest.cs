using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : Singleton<Quest>
{
    public QuestUIManager Manager;

    public QuestSO CurrentQuest;

    public int Step;

    public int QuestCompleted;

    private void Awake()
    {
        Step = 0;
    }

    public void LoadQuest(QuestData data)
    {
        Step = data.Step;
        QuestCompleted = data.QuestCompleted;
    }

    public void StartQuest(QuestUIManager manager)
    {
        Manager = manager;
        CurrentQuest = Manager.Quests[QuestCompleted];
    }

    public void StepQuest()
    {
        Step++;

        //Manager.UpdateUI();
        if (Step == CurrentQuest.Steps)
        {
            QuestCompleted++;

            Step = 0;
            StartQuest(Manager);
        }

        Manager.UpdateUI();
    }
}
