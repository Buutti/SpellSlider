using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
        setToOrigin();
        Screen.orientation = ScreenOrientation.Portrait;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void setToOrigin() {
        transform.localPosition = new Vector3(
            Camera.main.orthographicSize * Camera.main.aspect,
            Camera.main.orthographicSize,
            transform.localPosition.z
        );

    }
}
