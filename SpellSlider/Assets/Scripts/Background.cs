using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    //int nativeWidth = 1440;
    //int nativeHeigh = 2560;

	// Use this for initialization
	void Start () {
        resizeSpriteToScreen(gameObject);
	}

    public static void resizeSpriteToScreen(GameObject go)
    {
        SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
        if(sr != null) {
            float spriteWidth = sr.sprite.bounds.size.x;
            float spriteHeight = sr.sprite.bounds.size.y;

            float worldScreenHeight = Camera.main.orthographicSize * 2;
            float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

			go.transform.localScale= new Vector3(worldScreenWidth / spriteWidth,
            worldScreenHeight / spriteHeight, 1);

			go.transform.position = new Vector3(0, 0, go.transform.position.z);
        }
    }
}
