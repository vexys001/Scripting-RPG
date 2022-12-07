using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterManager : Singleton<EncounterManager>
{
    [SerializeField] private float _distanceToEnc = 3;

    private void Start()
    {
        _distanceToEnc = Random.Range(7.5f, 15);
    }

    public void Countdown(float distTraveled)
    {
        if(_distanceToEnc > 0)
        {
            _distanceToEnc -= distTraveled;
        }
        else
        {
            _distanceToEnc = Random.Range(7.5f, 15);
            SceneLoader.Instance.LoadEncounter();
        }
    }
}
