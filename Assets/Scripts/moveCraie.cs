using UnityEngine;
using System.Collections;

public class moveCraie : MonoBehaviour {
	
	public Vector3 depart;
	public Vector3 arrivee;
	public GameObject objet;
	
	private float dMin = 0.10f;
	private float speedCarre;
	private float speedX;
	private float speedY;
	private float scaleDiff;
	
	// Use this for initialization
	void Start () {
		speedCarre = 0.04f;
		speedX = (arrivee.x - depart.x)*speedCarre; 
		speedY = (arrivee.y - depart.y)*speedCarre;
		
		Vector3 screenPoint =new Vector3 (250f, 250f, 20f);
		var worldPos = GameObject.Find("Main Camera").camera.ScreenToWorldPoint ( screenPoint );
		//var obj = Instantiate( objet , worldPos, Quaternion.identity );
		
		objet.transform.position = worldPos;
		scaleDiff = speedCarre * 0.8f;
		Debug.Log (depart);
	}
	
	// Update is called once per frame
	void Update () {
		float d = Mathf.Pow (objet.transform.position.x -arrivee.x, 2) + Mathf.Pow (objet.transform.position.y-arrivee.y, 2);
		//Debug.Log (d);
		if (d < dMin) {
			Destroy(objet);
		} else {
			objet.transform.Translate (new Vector3 (speedX, speedY, 0));
			objet.transform.localScale -= new Vector3(scaleDiff, scaleDiff, 0);
		}
	}
}
