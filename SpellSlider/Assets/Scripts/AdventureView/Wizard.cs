using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wizard : MonoBehaviour {
	
	public float wizardHealth = 100;
	public bool alive = true;
    public float speed;

    public bool isMoving;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(isMoving) {
            MoveWizard();
            if(transform.position.x >= Camera.main.GetComponent<MainCamera>().ScreenWidth) {
                SceneManager.LoadScene("Win");
            }
        }
	}

    public void StartMoving() {
        isMoving = true;
    }

    public void StopMoving() {
        isMoving = false;
    }

    private void MoveWizard() {
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
    }

    public void wizardAliveChecker()
	{
		if (wizardHealth <= 0) 
		{
			alive = false;
		}
	}

}
