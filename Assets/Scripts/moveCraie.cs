using UnityEngine;
using System.Collections;

public class moveCraie : MonoBehaviour {
	
	public Vector3 depart;
	public Vector3 arrivee;
	
	
	private float dMin = 10.10f;
	private float speedCarre;
	private float speedX;
	private float speedY;
	private float speedZ;

	private float scaleDiff;
	
	// Use this for initialization
	void Start () {
		speedCarre = 0.02f;
		speedX = (arrivee.x - depart.x)*speedCarre; 
		speedY = (arrivee.y - depart.y)*speedCarre;
		speedZ = (arrivee.z - depart.z)*speedCarre;
		scaleDiff = 0.1f;
	
		transform.localScale = new Vector3 (scaleDiff, scaleDiff, 0);				
		transform.position = depart;

		Debug.Log (depart);
	}
	
	// Update is called once per frame
	void Update () {
		float d = Mathf.Pow (transform.position.x -arrivee.x, 2) 
			+ Mathf.Pow (transform.position.y-arrivee.y, 2)
				+ Mathf.Pow (transform.position.z-arrivee.z, 2);
		//Debug.Log (d);
		if (d < dMin) {
			Destroy(gameObject);
		} else {
			transform.Translate (new Vector3 ( speedX,  speedY, speedZ));
			//objet.transform.localScale -= new Vector3(scaleDiff, scaleDiff, 0);
		}
	}
}
