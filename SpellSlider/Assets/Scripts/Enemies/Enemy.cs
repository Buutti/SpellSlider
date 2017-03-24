using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    public List<SpellPattern> enemyPatterns { get; set; }
	//Time that the enemy waits before attacking in seconds
	//Used by basicAttackFunction
	float attackTimer = 0.5f;
	public Text SpellText;

    /// <summary>
    /// Return the number of patterns remaining
    /// </summary>
    public int PatternsRemaining
    {
        get
        {
            if (enemyPatterns != null)
            {
                return enemyPatterns.Count;
            }
            return 0;
        }
    }

    /// <summary>
    /// Returns current pattern in enemy patterns
    /// </summary>
    /// <returns></returns>
    public SpellPattern CurrentPattern
    {
        get
        {
            if (PatternsRemaining == 0)
            {
                return null;
            }
            else return enemyPatterns[0];
        }
    }

    /// <summary>
    /// Removes the first pattern in enemyPatterns
    /// </summary>
    public void RemovePattern()
    {
        if (PatternsRemaining != 0)
        {
            enemyPatterns.RemoveAt(0);
        }
    }

    /// <summary>
    /// Returns true if a given spell pattern matches current pattern in spell patterns
    /// </summary>
    /// <param name="spellPattern">Spell pattern to match</param>
    /// <returns></returns>
    public bool MatchPattern(SpellPattern spellPattern)
    {
        if (PatternsRemaining != 0)
        {
            return enemyPatterns[0].Equals(spellPattern);
        }
        return false;
    }

    /// <summary>
    /// Set spell pattern and other instance variables
    /// </summary>
    public abstract void Initialize();

	void Update(){
		//basicAttackFunction();
	}
	//Basic attack for enemys
	public void basicAttackFunction()
	{
		if (gameObject.transform.position.x<= 0)
		{
			
			attackTimer -= Time.deltaTime;
			if (attackTimer <= 0) {
				SpellText.text = "The enemy hit you!";
				Wizard wizard = GameObject.Find ("wizard").GetComponent<Wizard> ();
				wizard.wizardHealth = wizard.wizardHealth - 10;
			}
		}

	}

	
}
