using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    [SerializeField] private string _lastLevelName;

    public void Load(string level)
    {
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }

    public void LoadLastLevel()
    {
        SceneManager.LoadScene(_lastLevelName, LoadSceneMode.Single);
    }

    public void LoadEncounter()
    {
        _lastLevelName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene("Encounter", LoadSceneMode.Single);
    }
}
