using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public static EnemyManager Instance;
    public Enemy SquareMonster;
    public Enemy TurboSquareMonster;

    private Dictionary<EnemyType, Enemy> Enemies;
    public enum EnemyType {
        SquareMonster,
        TurboSquareMonster
    }

    private void Awake()
    {
        if(Instance != null) {
            Destroy(gameObject);
        }
        else {
            Instance = this;
            Enemies = new Dictionary<EnemyType, Enemy>();
            Enemies.Add(EnemyType.SquareMonster, SquareMonster);
            Enemies.Add(EnemyType.TurboSquareMonster, TurboSquareMonster);
        }
    }

    public Enemy GetEnemy(EnemyType enemyType) {
        return Enemies[enemyType];
    }
}
