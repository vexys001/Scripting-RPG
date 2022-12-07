using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestData", menuName = "ScriptableObjects/QuestSOs", order = 1)]
public class QuestSO : ScriptableObject
{
    public string Text;

    public int Steps;
}
