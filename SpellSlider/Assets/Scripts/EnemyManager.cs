using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public static EnemyManager Instance;
    public GameObject SquareMonster;
    public GameObject TurboSquareMonster;

    private Dictionary<EnemyType, GameObject> Enemies;
    public enum EnemyType {
        SquareMonster,
        TurboSquareMonster
    }

    private void Start()
    {
        if(Instance != null) {
            Destroy(gameObject);
        }
        else {
            Instance = this;
            Enemies = new Dictionary<EnemyType, GameObject>();
            Enemies.Add(EnemyType.SquareMonster, SquareMonster);
            Enemies.Add(EnemyType.TurboSquareMonster, TurboSquareMonster);
        }
    }

    public GameObject GetEnemy(EnemyType enemyType) {
        return Enemies[enemyType];
    }
}
