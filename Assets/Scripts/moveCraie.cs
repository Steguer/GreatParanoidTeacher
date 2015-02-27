using UnityEngine;
using System.Collections;

public class moveCraie : MonoBehaviour {

	public float x_depart;
	public float y_depart;

	public float x_arrivee;
	public float y_arrivee;

	public GameObject objet;

	private float dMin = 0.10f;

	private float speedCarre;
	private float speedX;
	private float speedY;

	private float scaleDiff;

	// Use this for initialization
	void Start () {
		speedCarre = 0.05f;
		speedX = (x_arrivee - x_depart)*speedCarre; 
		speedY = (y_arrivee - y_depart)*speedCarre;
		objet.transform.position = new Vector3(x_depart, y_depart, 0);
		scaleDiff = speedCarre * 0.8f;

	}
	
	// Update is called once per frame
	void Update () {
		float d = Mathf.Pow (objet.transform.position.x -x_arrivee, 2) + Mathf.Pow (objet.transform.position.y-y_arrivee, 2);
		Debug.Log (d);
		if (d < dMin) {
			Destroy(objet);
		} else {
			objet.transform.Translate (new Vector3 (speedX, speedY, 0));
			objet.transform.localScale -= new Vector3(scaleDiff, scaleDiff, 0);
		}
	}
}
