using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObjects : MonoBehaviour {

    public float HeightRatio;
	// Use this for initialization
	void Start () {
        Transform adventureBackgroundTransform = gameObject.transform.Find("AdventureBackground");
        if(adventureBackgroundTransform != null) {
            ResizeMeshAdventureView(gameObject, adventureBackgroundTransform.gameObject.GetComponent<MeshRenderer>(), HeightRatio);
        }
	}

    /// <summary>
    /// Resizes the background object container
    /// </summary>
    /// <param name="go">Object to be scaled</param>
    /// <param name="meshRenderer">MeshRenderer of the object we want stretched</param>
    /// <param name="heightRatio">Desired height ratio of the stretched object. 1 = full screen height</param>
    private static void ResizeMeshAdventureView(GameObject go, MeshRenderer meshRenderer, float heightRatio)
    {
        if (meshRenderer != null && go != null)
        {
            // Get the current bounds of meshRenderer
            float meshWidth = meshRenderer.bounds.size.x;
            float meshHeight = meshRenderer.bounds.size.y;

            // Get the size of camera
            float worldScreenHeight = (Camera.main.orthographicSize * 2) * heightRatio;
            float worldScreenWidth = ((Camera.main.orthographicSize * 2) / Screen.height * Screen.width);

            // Scale container so that meshRenderer fills the whole width of the screen
            go.transform.localScale = new Vector3(worldScreenWidth / meshWidth,
            worldScreenHeight / meshHeight, 1);
        }
    }
}
