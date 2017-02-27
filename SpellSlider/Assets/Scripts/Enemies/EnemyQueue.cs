using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyQueue : MonoBehaviour
{

    public List<Enemy> EnemiesDrawn;
    public float Offset;

    public void Awake()
    {
        EnemiesDrawn = new List<Enemy>();
    }

    /// <summary>
    /// Return the first enemy on list or null if list empty
    /// </summary>
    public Enemy CurrentEnemy
    {
        get
        {
            if (EnemiesDrawn.Count > 0)
            {
                return EnemiesDrawn[0];
            }
            else return null;
        }
    }

    /// <summary>
    /// Return true if enemy list is empty or null.
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty() {
        if(EnemiesDrawn == null || EnemiesDrawn.Count == 0) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Add enemy to enemy list
    /// </summary>
    /// <param name="enemy">Enemy to be added</param>
    public void AddEnemy(Enemy enemy) {
        if(EnemiesDrawn!= null) {
            DrawEnemy(enemy);
        }
        else {
            EnemiesDrawn = new List<Enemy>();
            DrawEnemy(enemy);
        }
    }

    /// <summary>
    /// Destroy the first enemy on the list and removes the drawn gameobject
    /// </summary>
    public void DestroyCurrentEnemy() {
        if(!IsEmpty()) {
            Destroy(EnemiesDrawn[0].gameObject);
            EnemiesDrawn.RemoveAt(0);
        }
    }

    public void DrawEnemy(Enemy enemy) {
        Vector3 offsetVector = new Vector3()
        {
            x = (EnemiesDrawn.Count * Offset),
            y = 0,
            z = 0
        };
        Vector3 startPosition = gameObject.transform.position + offsetVector;
        Enemy drawnEnemy = Instantiate(enemy, startPosition, Quaternion.identity, gameObject.transform);
        drawnEnemy.Initialize();
        EnemiesDrawn.Add(drawnEnemy);
    }
}
