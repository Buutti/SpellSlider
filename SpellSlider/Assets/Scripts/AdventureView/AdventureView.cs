using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureView : MonoBehaviour {

    Level currentLevel;
    public EnemyManager EnemyManager;
    public EnemyQueue EnemyQueue;
    Enemy CurrentEnemy;
	// Use this for initialization
	void Start () {
        Level level = FindObjectOfType<Level>();
        if(level != null) {
            currentLevel = level;
            foreach(EnemyManager.EnemyType enemyType in currentLevel.EnemyTypeList) {
                EnemyQueue.AddEnemy(EnemyManager.GetEnemy(enemyType));
            }
            EnemyQueue.DrawEnemies();
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
