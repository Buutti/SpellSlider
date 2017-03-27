using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyQueue : MonoBehaviour
{
    private Vector3 QueueStartingPosition;    

    public List<Enemy> EnemiesDrawn;
    public float StartingOffset;
    public float EnemyOffset;
    public float Speed;

    AdventureView adventureView;

    public void Awake()
    {
        QueueStartingPosition = gameObject.transform.position;
        EnemiesDrawn = new List<Enemy>();
        adventureView = gameObject.GetComponentInParent<AdventureView>();
    }

    public void Update()
    {
        if(adventureView.IsMoving)
        {
            MoveEnemyQueue();
        }
    }

    /// <summary>
    /// Moves EnemyQueue until Current enemy is at the starting position of the queue
    /// </summary>
    private void MoveEnemyQueue()
    {
        // Move background until current enemy is at first queue position
        transform.position -= new Vector3(Speed, 0, 0) * Time.deltaTime;
        if (!IsEmpty() && CurrentEnemy.transform.position.x <= QueueStartingPosition.x)
        {
            adventureView.StopMoving();
        }
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

    /// <summary>
    /// Instantiate and initialize new enemy and add to EnemiesDrawn
    /// </summary>
    /// <param name="enemy">Enemy to be added</param>
    public void DrawEnemy(Enemy enemy) {
        // Get horizontal offset
        Vector3 offsetVector = new Vector3()
        {
            x = (EnemiesDrawn.Count * EnemyOffset) + StartingOffset,
            y = 0,
            z = 0
        };
        Vector3 startPosition = gameObject.transform.position + offsetVector; 
        Enemy drawnEnemy = Instantiate(enemy, startPosition, Quaternion.identity, gameObject.transform);
        drawnEnemy.Initialize();
        EnemiesDrawn.Add(drawnEnemy);
    }
}
