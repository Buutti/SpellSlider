using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureView : MonoBehaviour
{

    Level currentLevel;
    private bool isMoving;
    private System.Random rng;

    public EnemyManager EnemyManager;
    public EnemyQueue EnemyQueue;
    public Text SpellText;
    public Wizard wizard;

    // Use this for initialization
    void Start()
    {
        ///<summary>For randomizing enemy queue</summary>
        rng = new System.Random();
        // Load level
        Level level = FindObjectOfType<Level>();
        if (level != null)
        {
            currentLevel = level;

            List<Enemy> enemyList = new List<Enemy>();
            // Read enemies from level
            foreach (EnemyCount enemyCount in currentLevel.EnemyCountList)
            {
                for(int i = 0; i < enemyCount.Count; i++) {
                    enemyList.Add(EnemyManager.GetEnemy(enemyCount.EnemyType));
                }
            }
            if(currentLevel.Randomized) {
                enemyList.Shuffle(rng);
            }
            // Populate enemy queue
            foreach (Enemy enemy in enemyList) {
                EnemyQueue.AddEnemy(enemy); 
            }
        }
        StartMoving();
    }

    /// <summary>
    /// Returns true if adventure view is moving
    /// </summary>
    public bool IsMoving
    {
        get { return isMoving; }
    }

    /// <summary>
    /// Start moving adventure view
    /// </summary>
    public void StartMoving() {
        isMoving = true;
        //Move, damn it!
        wizard.GetComponent<Animator>().Play("Entry");
    }

    /// <summary>
    /// Stop moving adventure view
    /// </summary>
    public void StopMoving() {
        isMoving = false;
        wizard.GetComponent<Animator>().Stop();
    }



    /// <summary>
    /// Run when pattern is finished in the SpellGrid. 
    /// </summary>
    /// <param name="spellPattern">Pattern received from the spell grid</param>
    public void PatternDrawn(SpellPattern spellPattern)
    {
        if (EnemyQueue.IsEmpty())
        {
            // Queue is empty, do nothing
            SpellText.text = "Queue empty";
            return;
        }
        if (EnemyQueue.CurrentEnemy.MatchPattern(spellPattern))
        {
            // Matching pattern -> remove pattern from enemy
            SpellText.text = "Matching pattern!";
            EnemyQueue.CurrentEnemy.RemovePattern();
            if (EnemyQueue.CurrentEnemy.PatternsRemaining == 0)
            {
                // No patterns remaining on the enemy -> Destroy enemy
                EnemyQueue.DestroyCurrentEnemy();
                StartMoving();
            }
        }
        else
        {
            // Wrong pattern received from SpellGrid -> Hurt wizard!
            SpellText.text = "Wrong pattern";
            // PUNISH WIZARD HERE
            return;
        }
    }

}
