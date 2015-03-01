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
		try{
		int combo = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ().combo;
		t.text = "x" + combo;
		}catch (System.NullReferenceException e)
		{
		}
	}
}
