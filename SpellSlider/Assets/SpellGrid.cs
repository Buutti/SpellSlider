using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellGrid : MonoBehaviour {

    List<SpellButton> spellButtons;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Change button color and add button to spellButtons list
    void ButtonActivate(SpellButton spellButton)
    {
        spellButton.GetComponent<SpriteRenderer>().color = Color.red;
        spellButtons.Add(spellButton);
    }

}
