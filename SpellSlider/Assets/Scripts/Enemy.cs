using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int speed;
    Vector3 startingPosition = new Vector3();

	// Use this for initialization
    // Initializing monster's starting position
	void Start () {
        startingPosition = transform.position;
	}
	
	// Update is called once per frame
    // Moving the monster
	void Update () {
    }
}
