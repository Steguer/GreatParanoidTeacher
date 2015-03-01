using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FrameScaling : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject img=GameObject.Find ("Image");
		img.GetComponent<RectTransform> ().sizeDelta = new Vector2(Screen.width, Screen.height);
	}
}
