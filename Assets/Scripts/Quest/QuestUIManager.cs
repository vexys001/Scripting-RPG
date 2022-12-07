using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestUIManager : MonoBehaviour
{
    public TextMeshProUGUI QuestText;

    public QuestSO[] Quests;
    // Start is called before the first frame update
    void Start()
    {
        Quest.Instance.StartQuest(this);
        UpdateUI();
    }

    public void UpdateUI()
    {
        QuestText.text = Quest.Instance.CurrentQuest.Text + ": " + Quest.Instance.Step + "/" + Quest.Instance.CurrentQuest.Steps;
    }
}
