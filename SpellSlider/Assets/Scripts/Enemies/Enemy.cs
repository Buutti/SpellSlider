using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected static EnemyManager.EnemyType type;
    protected static int speed;
    protected List<SpellPattern> enemyPatterns { get; set; }
    
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
    /// Removes the first pattern in enemyPatterns
    /// </summary>
    public void RemovePattern() {
        if(PatternsRemaining != 0) {
            enemyPatterns.RemoveAt(0);
        }
    }

    /// <summary>
    /// Returns true if a given spell pattern matches current pattern in spell patterns
    /// </summary>
    /// <param name="spellPattern">Spell pattern to match</param>
    /// <returns></returns>
    public bool MatchPattern(SpellPattern spellPattern) {
        if(PatternsRemaining != 0) {
            return enemyPatterns[0].Equals(spellPattern);
        }   
        return false;
    }


}
