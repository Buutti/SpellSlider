using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureView : MonoBehaviour {

    public float PartitionSize;
	// Use this for initialization
	void Start () {
        gameObject.transform.position = new Vector3
        {
            x = 0,
            y = Camera.main.orthographicSize * 2,
            z = gameObject.transform.position.z
        };
        MeshRenderer adventureBackgroundSpriteRenderer= GameObject.Find("AdventureBackground")
        .GetComponent<MeshRenderer>();
        resizeSpriteAdventureView(adventureBackgroundSpriteRenderer);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void resizeSpriteAdventureView(MeshRenderer meshRenderer)
    {
        if (meshRenderer != null)
        {
            float meshWidth = meshRenderer.bounds.size.x;
            float meshHeight = meshRenderer.bounds.size.y;

            float worldScreenHeight = (Camera.main.orthographicSize * 2) / PartitionSize;
            float worldScreenWidth = ((Camera.main.orthographicSize * 2) / Screen.height * Screen.width);

            gameObject.transform.localScale = new Vector3(worldScreenWidth / meshWidth,
            worldScreenHeight / meshHeight, 1);
        }
    }
}
