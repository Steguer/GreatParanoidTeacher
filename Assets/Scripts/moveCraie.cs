using UnityEngine;
using System.Collections;

public class moveCraie : MonoBehaviour {
	
	public Vector3 depart;
	public Vector3 arrivee;
	public GameObject studentTargeted = null;
	public float speedCarre = 0.05f;
	
	private float dMin = 10.10f;
	private float speedX;
	private float speedY;
	private float speedZ;

	private float scaleDiff;
	
	// Use this for initialization
	void Start () {
		speedCarre = 0.04f;
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
			GameObject.Find ("SoundMaker").GetComponent<SoundMaker> ().playRandomHitSound (); //son d'impact
			if(studentTargeted != null) {
				studentTargeted.transform.GetComponent<Student>().Hit();
			}
			Destroy(gameObject);
		} else {
			transform.Translate (new Vector3 ( speedX,  speedY, speedZ));
			//objet.transform.localScale -= new Vector3(scaleDiff, scaleDiff, 0);
		}
	}
}
