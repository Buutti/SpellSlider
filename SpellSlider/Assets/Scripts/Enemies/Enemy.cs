using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {
    protected static EnemyManager.EnemyType type;
    protected static int speed;

    protected abstract SpellPattern SpellPattern { get; }

    protected bool MatchingPattern(SpellPattern spellPattern) {
        return SpellPattern.Equals(spellPattern);
    }

}
