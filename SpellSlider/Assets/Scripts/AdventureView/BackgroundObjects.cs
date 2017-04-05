using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObjects : MonoBehaviour
{

    private GameObject Background;
    private GameObject Ceiling;
    private GameObject Walls;
    private GameObject Ground;

    // Use this for initialization
    void Awake()
    {
        // Find children
        Background = gameObject.transform.Find("Background").gameObject;
        Ceiling = gameObject.transform.Find("Ceiling").gameObject;
        Walls = gameObject.transform.Find("Walls").gameObject;
        Ground = gameObject.transform.Find("Ground").gameObject;
    }

    private void Start()
    {
        Level level = FindObjectOfType<Level>();
        if (level != null) { LoadMaterials(level); }
    }

    /// <summary>
    /// Load materials from level object and set the materials to appropriate background objects
    /// </summary>
    /// <param name="level">Level containing the materials</param>
    public void LoadMaterials(Level level)
    {
        if (level.BackgroundMaterial != null) { Background.GetComponent<MeshRenderer>().material = level.BackgroundMaterial; }
        if (level.CeilingMaterial != null) { Ceiling.GetComponent<MeshRenderer>().material = level.CeilingMaterial; }
        if (level.WallMaterial != null) { Walls.GetComponent<MeshRenderer>().material = level.WallMaterial; }
        if (level.GroundMaterial != null) { Ground.GetComponent<MeshRenderer>().material = level.GroundMaterial; }
    }
}
