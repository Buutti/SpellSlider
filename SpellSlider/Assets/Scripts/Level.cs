using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level : MonoBehaviour {
    
    /// <summary>
    /// Queue containing all the enemies in the level
    /// </summary>
    public List<EnemyManager.EnemyType> EnemyQueue;

}
