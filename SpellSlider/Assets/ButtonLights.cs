using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLights : MonoBehaviour {

    int fingerId = -1; // The first finger id
    public GameObject[] buttons = new GameObject[9];
    CircleCollider2D[] buttonCol = new CircleCollider2D[9];

    // Use this for initialization
    void Start () {
        
        // Getting colliders
        for(int i = 0; i < 9; i++)
        {
            buttonCol[i] = buttons[i].GetComponent<CircleCollider2D>();
        }

	}
	
	// Update is called once per frame
	void Update () {


        HandleTouch();

	}

    // Get touch and move spell cursor
    private void HandleTouch()
    {
        if (fingerId < 0 && Input.touchCount > 0)
        {
            // Get first touch from Input.touches
            fingerId = Input.touches[0].fingerId;
        }
        
        else if (fingerId >= 0 || Input.GetMouseButton(0))
        {
            try
            {
                Vector2 position;
                if (Input.GetMouseButton(0))
                {
                    position = Input.mousePosition;
                }
                else
                {
                    Touch touch = Input.GetTouch(fingerId);
                    position = touch.position;
                }
               
                for(int i = 0; i < 9; i++)
                {
                    if (buttonCol[i].bounds.Contains(position))
                    {
                        print("Point is inside collider");
                        buttons[i].GetComponent<Image>().color = new Color32(255, 255, 225, 100);
                    }
                }
                
                if(Input.GetTouch(fingerId).phase == TouchPhase.Ended)
                {
                    endTouch();
                }

            }
           

            catch (ArgumentException)
            {
                // Finger index out of bounds
                // Reset finger id
                fingerId = -1;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            endTouch();
        }
    }

    void endTouch()
    {
        print("Touch ended");
        for (int i = 0; i < 9; i++)
        {
            buttons[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }
}
