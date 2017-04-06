using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureViewBackgroundObject : MonoBehaviour
{
	public float moveAmount;
    Vector3 StartingPosition;
    AdventureView adventureView;

    public int Speed;

    // Use this for initialization
    // Initializing monster's starting position
    void Start()
    {
        StartingPosition = transform.position;
		//Debug.Log ("STARTING AT " + transform.position.x + " OR " + transform.localPosition.x);
        adventureView = gameObject.transform.parent.GetComponentInParent<AdventureView>();
    }

    // Update is called once per frame
    // Moving the monster
    void Update()
    {
        if(adventureView.IsMoving) {
            transform.position -= new Vector3(Speed, 0, 0) * Time.deltaTime;
            // if monster reaches the wizard, it is transported back
            if (transform.position.x <= 0)
            {
				transform.position += moveAmount*Vector3.right;
            }
        }
    }
}