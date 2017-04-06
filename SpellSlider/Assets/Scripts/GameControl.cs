using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {
    public static GameControl Instance;

    public Level CurrentLevel;

	// Use this for initialization
	void Awake () {
        
		if(Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if( Instance != this) {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
