using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellButton : MonoBehaviour {

    public string ID;
    public Vector2 Position;
    public int touchCount;
    public bool Activated;

    private void Start()
    {
        touchCount = 0;
        Activated = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SendMessageUpwards("SpellButtonActivate", this, SendMessageOptions.RequireReceiver);
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (!Activated)
    //    {
    //        SendMessageUpwards("SpellButtonActivate", this, SendMessageOptions.RequireReceiver);
    //    }
    //}
}
