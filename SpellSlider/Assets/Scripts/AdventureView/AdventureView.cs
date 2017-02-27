using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureView : MonoBehaviour {

    Level currentLevel;
    public EnemyManager EnemyManager;
    public EnemyQueue EnemyQueue;
    public Text SpellText;
	// Use this for initialization
	void Start () {
        Level level = FindObjectOfType<Level>();
        if(level != null) {
            currentLevel = level;
            foreach(EnemyManager.EnemyType enemyType in currentLevel.EnemyTypeList) {
                EnemyQueue.AddEnemy(EnemyManager.GetEnemy(enemyType));
            }
        }

	}
	
    /// <summary>
    /// Run when pattern is finished in the SpellGrid. 
    /// </summary>
    /// <param name="spellPattern">Pattern received from the spell grid</param>
    public void PatternDrawn(SpellPattern spellPattern) {
        if(EnemyQueue.IsEmpty()) {
            // Queue is empty, do nothing
            SpellText.text = "Queue empty";
            return;
        }
        SpellText.text = "";
        SpellText.text += "Spell pattern:" + spellPattern.ToString();
        SpellText.text += "\nEnemy pattern:" + EnemyQueue.CurrentEnemy.CurrentPattern.ToString();
        if(EnemyQueue.CurrentEnemy.MatchPattern(spellPattern)) {
            // Matching pattern -> remove pattern from enemy
            EnemyQueue.CurrentEnemy.RemovePattern();
            if(EnemyQueue.CurrentEnemy.PatternsRemaining == 0) {
                // No patterns remaining on the enemy -> Destroy enemy
                EnemyQueue.DestroyCurrentEnemy();
            }
        }
        else {
            // Wrong pattern received from SpellGrid -> Hurt wizard!
            SpellText.text = "Wrong pattern";
            // PUNISH WIZARD HERE
            return;
        }
    }
    
}
