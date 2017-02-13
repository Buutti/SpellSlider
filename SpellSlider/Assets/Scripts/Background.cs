using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    //int nativeWidth = 1440;
    //int nativeHeigh = 2560;

	// Use this for initialization
	void Start () {
        resizeSpriteToScreen();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void resizeSpriteToScreen() {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        float spriteWidth = sr.sprite.bounds.size.x;
        float spriteHeight = sr.sprite.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector3(worldScreenWidth / spriteWidth,
        worldScreenHeight / spriteHeight, 1);
    }
}
