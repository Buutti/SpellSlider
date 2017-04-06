using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureView : MonoBehaviour
{
    public static AdventureView Instance;
    public GameObject winPanel;
    public Text WinText;
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
        Instance = this;
        winPanel.SetActive(false);
        ///<summary>For randomizing enemy queue</summary>
        rng = new System.Random();
        // Load level
        Level level = GameControl.Instance.CurrentLevel ;
        if (level != null)
        {
            currentLevel = level;

            List<Enemy> enemyList = new List<Enemy>();
            // Read enemies from level
            foreach (EnemyCount enemyCount in currentLevel.EnemyCountList)
            {
                for (int i = 0; i < enemyCount.Count; i++)
                {
                    enemyList.Add(EnemyManager.GetEnemy(enemyCount.EnemyType));
                }
            }
            if (currentLevel.Randomized)
            {
                enemyList.Shuffle(rng);
            }
            // Populate enemy queue
            foreach (Enemy enemy in enemyList)
            {
                EnemyQueue.AddEnemy(enemy);
            }
        }
        StartMoving();
    }

    void Update()
    {
        //CheckAllEnemysDestroyed ();
        if(wizard.wizardHealth <= 0) {
            KillWizard();
        }
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
    public void StartMoving()
    {
        isMoving = true;
        wizard.GetComponent<Animator>().SetTrigger("StartWalking");
    }

    /// <summary>
    /// Stop moving adventure view
    /// </summary>
    public void StopMoving()
    {
        isMoving = false;
        wizard.GetComponent<Animator>().SetTrigger("StopWalking");
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
                if (EnemyQueue.IsEmpty())
                {
                    WinLevel();
                }
                else if (!IsMoving)
                {
                    StartMoving();
                }
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

    /// <summary>
    /// Launches the win cycle
    /// </summary>
    public void WinLevel()
    {
        if (IsMoving) { StopMoving(); }
        // Trigger win animation for wizard
        wizard.GetComponent<Animator>().SetTrigger("Win");
    }

    public void KillWizard() {
        wizard.GetComponent<Animator>().SetTrigger("Die");
    }

    public void LoseLevel() {
        WinText.text = "YOU LOSE BABY!";
        WinText.enabled = true;
    }

    public void CheckAllEnemysDestroyed()
    {
        if (EnemyQueue.IsEmpty())
        {
            //startWizardWalking (2);
            //Wait(2 Sec)
            winPanel.SetActive(true);
            isMoving = false;

        }

    }

}
