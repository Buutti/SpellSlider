using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public static EnemyManager Instance;
    public Enemy SquareMonster;
    public Enemy FireMonster;
    public Enemy IceMonster;
    public Enemy SandMonster;
	public Enemy TreeMonster;
	public Enemy WaterMonster;
	public Enemy WindMonster;

    private Dictionary<EnemyType, Enemy> Enemies;
    public enum EnemyType {
        RockMonster,
        FireMonster,
        IceMonster,
        SandMonster,
		TreeMonster,
		WaterMonster,
		WindMonster
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
			Enemies.Add(EnemyType.TreeMonster, TreeMonster);
			Enemies.Add(EnemyType.WaterMonster, WaterMonster);
			Enemies.Add(EnemyType.WindMonster, WindMonster);

        }
    }

    public Enemy GetEnemy(EnemyType enemyType) {
        return Enemies[enemyType];
    }
}
