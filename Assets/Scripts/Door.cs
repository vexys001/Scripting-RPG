using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string DoorTo;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (DoorTo == "EndScreen")
        {
            if (Quest.Instance.QuestCompleted == 1)
            {
                SceneLoader.Instance.Load(DoorTo);
            }
        }
        else
        {
            SceneLoader.Instance.Load(DoorTo);
        }
    }
}
