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
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
