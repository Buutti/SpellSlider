using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public enum Levels
    {
        LEVEL_1_1,
        LEVEL_1_2,
        EMPTY
    }

    private static Levels GetLevelEnum(string levelName)
    {
        try
        {
            Levels level = (Levels)Enum.Parse(typeof(Levels), levelName, true);
            return level;
        }
        catch (Exception)
        {
            return Levels.EMPTY;
        }
    }

    public void LoadLevel(string levelName)
    {
        GameObject level = PopulateLevel(GetLevelEnum(levelName));
        DontDestroyOnLoad(level);
        SceneManager.LoadScene("Game");
    }

    private static GameObject PopulateLevel(Levels levelEnum)
    {
        GameObject level = new GameObject();
        level.name = "Level";
        level.AddComponent<Level>();

        switch (levelEnum)
        {
            case Levels.LEVEL_1_1:
                level.GetComponent<Level>().EnemyQueue = new List<EnemyManager.EnemyType>
                {
                    EnemyManager.EnemyType.SquareMonster,
                    EnemyManager.EnemyType.SquareMonster,
                    EnemyManager.EnemyType.SquareMonster,
                    EnemyManager.EnemyType.SquareMonster,
                    EnemyManager.EnemyType.SquareMonster,
                    EnemyManager.EnemyType.SquareMonster
                };
                break;
            case Levels.LEVEL_1_2:
                level.GetComponent<Level>().EnemyQueue = new List<EnemyManager.EnemyType>
                {
                    EnemyManager.EnemyType.TurboSquareMonster,
                    EnemyManager.EnemyType.TurboSquareMonster,
                    EnemyManager.EnemyType.TurboSquareMonster,
                    EnemyManager.EnemyType.TurboSquareMonster,
                    EnemyManager.EnemyType.TurboSquareMonster,
                    EnemyManager.EnemyType.TurboSquareMonster
                };
                break;

            default:
                level.GetComponent<Level>().EnemyQueue = new List<EnemyManager.EnemyType>();
                break;
        }

        return level;
    }

}
