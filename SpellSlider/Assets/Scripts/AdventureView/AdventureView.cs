using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureView : MonoBehaviour {

    Level currentLevel;
    public EnemyManager EnemyManager;
    public List<Enemy> EnemyList;
	// Use this for initialization
	void Start () {
        EnemyList = new List<Enemy>();
        Level level = FindObjectOfType<Level>();
        if(level != null) {
            currentLevel = level;
            foreach(EnemyManager.EnemyType enemyType in currentLevel.EnemyTypeList) {
                EnemyList.Add(EnemyManager.GetEnemy(enemyType));
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
