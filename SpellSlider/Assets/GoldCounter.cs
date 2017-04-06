using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldCounter : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Text>().text = string.Format("Gold: {0}", GameControl.Instance.loot.Gold.ToString());
	}
}
