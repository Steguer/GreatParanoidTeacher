using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ComboScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Text t = this.GetComponent<Text>();
		t.text = "x" + (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().combo).ToString();
	}
}
