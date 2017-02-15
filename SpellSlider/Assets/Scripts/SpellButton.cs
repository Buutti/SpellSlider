using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellButton : MonoBehaviour {

    public int[] Coord; 

    // Send message to SpellGrid on collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SendMessageUpwards("ButtonActivate", this);
    }

}
