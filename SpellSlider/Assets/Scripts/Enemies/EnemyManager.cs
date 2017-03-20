using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public static EnemyManager Instance;
    public Enemy SquareMonster;
    public Enemy FireMonster;
    public Enemy IceMonster;
    public Enemy SandMonster;

    private Dictionary<EnemyType, Enemy> Enemies;
    public enum EnemyType {
        RockMonster,
        FireMonster,
        IceMonster,
        SandMonster
    }

    private void Awake()
    {
        if(Instance != null) {
            Destroy(gameObject);
        }
        else {
            Instance = this;
            Enemies = new Dictionary<EnemyType, Enemy>();
            Enemies.Add(EnemyType.RockMonster, SquareMonster);
            Enemies.Add(EnemyType.FireMonster, FireMonster);
            Enemies.Add(EnemyType.IceMonster, IceMonster);
            Enemies.Add(EnemyType.SandMonster, SandMonster);
        }
    }

    public Enemy GetEnemy(EnemyType enemyType) {
        return Enemies[enemyType];
    }
}
