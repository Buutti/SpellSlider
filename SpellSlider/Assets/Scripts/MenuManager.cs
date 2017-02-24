using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    
    public  void LoadLevel(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitLevel()
    {
        try
        {
            Level level = FindObjectOfType<Level>();

            if (level != null)
            {
                Destroy(level.gameObject);
            }
        
            SceneManager.LoadScene("LevelSelect");
        }
        catch (Exception e)
        {
            throw;
        }
    }
        
}
