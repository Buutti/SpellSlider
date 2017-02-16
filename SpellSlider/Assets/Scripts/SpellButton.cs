using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellButton : MonoBehaviour {

    /// <summary>
    /// Position of the button on the spell grid
    /// </summary>
    public Vector2 Position; 

    // Send message to SpellGrid on collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SendMessageUpwards("ButtonActivate", this);
    }

}
