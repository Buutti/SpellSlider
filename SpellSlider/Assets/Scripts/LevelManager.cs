using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public List<Level> LevelList;

    private Dictionary<string, Level> levelDictionary;

    private void Start()
    {
        levelDictionary = new Dictionary<string, Level>();
        foreach(Level level in LevelList) 
        {
            levelDictionary.Add(level.name, level);
        }
    }

    /// <summary>
    /// Load level and move to game scene.
    /// </summary>
    /// <param name="levelName">Name of the level to be loaded</param>
    public void LoadLevel(string levelName)
    {
        GameControl.Instance.CurrentLevel = Instantiate(GetLevel(levelName));
        DontDestroyOnLoad(GameControl.Instance.CurrentLevel);
        SceneManager.LoadScene("Game");
    }

    public Level GetLevel ( string levelName) {
        
        return levelDictionary[levelName];
    }

}
