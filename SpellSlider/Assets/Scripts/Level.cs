using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level : MonoBehaviour {

    public string Name;
    public Material BackgroundMaterial;
    public Material CeilingMaterial;
    public Material WallMaterial;
    public Material GroundMaterial;
    /// <summary>
    /// Queue containing all the enemies in the level
    /// </summary>
    public List<EnemyCount> EnemyCountList;

    /// <summary>
    /// Determines if enemy queue is randomized after creation
    /// </summary>
    public bool Randomized;

}
