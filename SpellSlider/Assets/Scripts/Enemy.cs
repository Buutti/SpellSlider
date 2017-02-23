using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject wizard;
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
        transform.position -= new Vector3(speed, 0, 0)*Time.deltaTime;

        // if monster reaches the wizard, it is transported back
        if(transform.position.x <= wizard.transform.position.x + 10)
        {
            transform.position = startingPosition;
        }
    }
}
