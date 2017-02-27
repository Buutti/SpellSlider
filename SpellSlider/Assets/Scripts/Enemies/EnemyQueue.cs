using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyQueue : MonoBehaviour
{

    private List<Enemy> enemyList;
    public List<Enemy> EnemiesDrawn;
    public float Offset;

    public void Awake()
    {
        enemyList = new List<Enemy>();
        EnemiesDrawn = new List<Enemy>();
    }

    /// <summary>
    /// Return the first enemy on list or null if list empty
    /// </summary>
    public Enemy CurrentEnemy
    {
        get
        {
            if (enemyList.Count > 0)
            {
                return enemyList[0];
            }
            else return null;
        }
    }

    /// <summary>
    /// Return true if enemy list is empty or null.
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty() {
        if(enemyList == null || enemyList.Count == 0) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Add enemy to enemy list
    /// </summary>
    /// <param name="enemy">Enemy to be added</param>
    public void AddEnemy(Enemy enemy) {
        if(enemyList != null) {
            enemyList.Add(enemy);
        }
        else {
            enemyList = new List<Enemy>();
            enemyList.Add(enemy);
        }
    }

    /// <summary>
    /// Destroy the first enemy on the list and removes the drawn gameobject
    /// </summary>
    public void DestroyCurrentEnemy() {
        if(!IsEmpty()) {
            Destroy(EnemiesDrawn[0].gameObject);
            enemyList.RemoveAt(0);
        }
    }

    /// <summary>
    /// Draw all enemies in enemyList and add all drawn objects to EnemiesDrawn
    /// </summary>
    public void DrawEnemies() {
        if(!IsEmpty()) {
            for(int i = 0; i < enemyList.Count; i++)
            {
                Vector3 offsetVector = new Vector3() {
                    x = (i * Offset),
                    y = 0,
                    z = 0
                };
                Vector3 startPosition = gameObject.transform.position + offsetVector;
                EnemiesDrawn.Add(Instantiate(enemyList[i], startPosition, Quaternion.identity, gameObject.transform));
            }
        }
    }

}
