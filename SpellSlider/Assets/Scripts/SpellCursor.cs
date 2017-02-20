using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpellCursor : MonoBehaviour {

    Image cursorImage;
    int fingerId = -1;

    // Use this for initialization
    void Start () {
        cursorImage = GetComponent<Image>();
        cursorImage.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        HandleTouch();
    }

    // Get touch and move spell cursor
    private void HandleTouch()
    {
        if (fingerId < 0 && Input.touchCount > 0)
        {
            // Get first touch from Input.touches
            fingerId = Input.touches[0].fingerId;
            SendMessageUpwards("TouchActivate");
            Debug.Log("Touch began");
        }
        else if (fingerId >= 0) 
        {
            try
            {
                Touch touch = Input.GetTouch(fingerId);
                switch (touch.phase)
                {
                    case TouchPhase.Moved:
                    // Finger moved -> move cursor
                        cursorImage.enabled = true;
                        moveSpell(touch);
                        break;

                    case TouchPhase.Ended:
                    // Touch ended -> Reset fingerId and hide cursor
                        fingerId = -1;
                        cursorImage.enabled = false ;
                        SendMessageUpwards("TouchEnd");
                        break;

                    case TouchPhase.Canceled:
                        fingerId = -1;
                        cursorImage.enabled = false;
                        SendMessageUpwards("TouchEnd");
                        break;

                    default:
                        break;
                }
            }

            catch (ArgumentException)
            {
                // Finger index out of bounds
                // Reset finger id
                fingerId = -1;
                // Disable spell cursor
                cursorImage.enabled = false;
            }
        }
    }

    string getTouchMessage(Touch touch)
    {
        string message = "";
        message += "ID: " + touch.fingerId + "\n";
        message += "Pos X: " + touch.position.x + "\n";
        message += "Pos Y: " + touch.position.y + "\n";

        return message;
    }


    /// <summary>
    /// Moves the spell cursor to touch position
    /// </summary>
    /// <param name="touch">Finger touch for moving the spell</param>
    void moveSpell(Touch touch) {
        
        // Calculate transform factor for screen to game world conversion
        // Note! Bottom left corner of camera must be placed at origin!
        float transformFactor = 1 / (Screen.height / (2 * Camera.main.orthographicSize));
        gameObject.transform.position = new Vector3(
            touch.position.x * transformFactor,
            touch.position.y * transformFactor,
            gameObject.transform.position.z
        );
    }
}
