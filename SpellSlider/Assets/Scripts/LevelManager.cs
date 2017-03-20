using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Level LEVEL_1_1;
    public Level LEVEL_1_2;
    public Level EMPTY;

    public enum Levels
    {
        LEVEL_1_1,
        LEVEL_1_2,
        LEVEL_1_3,
        LEVEL_1_4,
        LEVEL_1_5,
        EMPTY
    }

    private Dictionary<Levels, Level> levelDictionary;

    private void Start()
    {
        levelDictionary = new Dictionary<Levels, Level>();
        levelDictionary.Add(Levels.LEVEL_1_1, LEVEL_1_1);
        levelDictionary.Add(Levels.LEVEL_1_2, LEVEL_1_2);
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

    /// <summary>
    /// Load level and move to game scene.
    /// </summary>
    /// <param name="levelName">Name of the level to be loaded</param>
    public void LoadLevel(string levelName)
    {
        Level level = Instantiate(GetLevel(GetLevelEnum(levelName)));
        DontDestroyOnLoad(level);
        SceneManager.LoadScene("Game");
    }

    public Level GetLevel ( Levels level) {
        
        return levelDictionary[level];
    }

    private static GameObject PopulateLevel(Levels levelEnum)
    {
        GameObject level = new GameObject();
        level.name = "Level";
        level.AddComponent<Level>();

        //switch (levelEnum)
        //{
        //    case Levels.LEVEL_1_1:
        //        level.GetComponent<Level>().EnemyTypeList = new List<EnemyManager.EnemyType>
        //        {
        //            EnemyManager.EnemyType.RockMonster,
        //            EnemyManager.EnemyType.RockMonster,
        //            EnemyManager.EnemyType.RockMonster,
        //            EnemyManager.EnemyType.RockMonster,
        //            EnemyManager.EnemyType.RockMonster,
        //            EnemyManager.EnemyType.RockMonster
        //        };
        //        break;
        //    case Levels.LEVEL_1_2:
        //        level.GetComponent<Level>().EnemyTypeList = new List<EnemyManager.EnemyType>
        //        {
        //            EnemyManager.EnemyType.RockMonster,
        //            EnemyManager.EnemyType.IceMonster,
        //            EnemyManager.EnemyType.FireMonster,
        //            EnemyManager.EnemyType.SandMonster,
        //        };
        //        break;

        //    default:
        //        level.GetComponent<Level>().EnemyTypeList = new List<EnemyManager.EnemyType>();
        //        break;
        //}

        return level;
    }

}
