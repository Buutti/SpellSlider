using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public GameObject Fill;
    
    private Wizard wizard;
    private float maxWizardHealth;
    private float maxHealthBarWidth;
    private LineRenderer healthBarFill;
    private Vector3 healtBarFillStartPosition;
	// Use this for initialization
	void Start () {
	    wizard = FindObjectOfType<Wizard>();
        maxWizardHealth = wizard.wizardHealth;
        maxHealthBarWidth = Fill.GetComponent<RectTransform>().rect.width;
        healthBarFill = Fill.GetComponent<LineRenderer>();
        healtBarFillStartPosition = healthBarFill.GetPosition(0);
        UpdateHealthBarWidth();
    }
	
	// Update is called once per frame
	void Update () {
        UpdateHealthBarWidth();
	}

    private void UpdateHealthBarWidth() {
        float healthBarWidth = maxHealthBarWidth * (wizard.wizardHealth / maxWizardHealth);
        Vector3 newEndPosition = new Vector3(healtBarFillStartPosition.x + healthBarWidth, healtBarFillStartPosition.y, healtBarFillStartPosition.z);
        healthBarFill.SetPosition(1, newEndPosition);
    }
}
