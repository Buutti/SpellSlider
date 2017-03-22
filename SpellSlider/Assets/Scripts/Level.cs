using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level : MonoBehaviour {
    
    /// <summary>
    /// Queue containing all the enemies in the level
    /// </summary>
    public List<EnemyCount> EnemyCountList;

    /// <summary>
    /// Determines if enemy queue is randomized after creation
    /// </summary>
    public bool Randomized;

}
