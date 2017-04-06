using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObjects : MonoBehaviour
{
    public float HeightRatio;

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

        ResizeMeshAdventureView();
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

    /// <summary>
    /// Resizes the background object container
    /// </summary>
    /// <param name="go">Object to be scaled</param>
    /// <param name="meshRenderer">MeshRenderer of the object we want stretched</param>
    /// <param name="heightRatio">Desired height ratio of the stretched object. 1 = full screen height</param>
    private void ResizeMeshAdventureView()
    {
        Transform adventureBackgroundTransform = gameObject.transform.Find("Background");
        MeshRenderer meshRenderer = adventureBackgroundTransform.GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            // Get the current bounds of meshRenderer
            float meshWidth = meshRenderer.bounds.size.x;
            float meshHeight = meshRenderer.bounds.size.y;

            // Get the size of camera
            float worldScreenHeight = (Camera.main.orthographicSize * 2) * HeightRatio;
            float worldScreenWidth = ((Camera.main.orthographicSize * 2) / Screen.height * Screen.width);

            // Calculate scale
            float scaleX = worldScreenWidth / meshWidth;
            float scaleY = worldScreenHeight / meshHeight;

            // Scale container so that meshRenderer fills the whole width of the screen
            gameObject.transform.localScale = new Vector3(scaleX, scaleY, 1);

            // Update bgObject move amounts so background objects cycle properly
            AdventureViewBackgroundObject[] objects = gameObject.transform.GetComponentsInChildren<AdventureViewBackgroundObject>();
            foreach(AdventureViewBackgroundObject bgObject in objects) {
                bgObject.moveAmount = bgObject.moveAmount * scaleX;
            }
            
        }
    }
}
