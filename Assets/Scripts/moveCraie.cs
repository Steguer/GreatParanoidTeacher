using UnityEngine;
using System.Collections;

public class moveCraie : MonoBehaviour {
	
	public Vector3 depart;
	public Vector3 arrivee;
	public GameObject studentTargeted = null;
	public float speedCarre = 0.05f;
	public GameObject bam;
	
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
				GameObject bamObject = initBam();
				studentTargeted.transform.GetComponent<Student>().Hit();
				Destroy (bamObject, 0.3f);
			}
			Destroy(gameObject);

		} else {
			transform.Translate (new Vector3 ( speedX,  speedY, speedZ));

			//objet.transform.localScale -= new Vector3(scaleDiff, scaleDiff, 0);
		}
	}



	GameObject initBam(){
		Vector3 posStudent = studentTargeted.transform.position;
		Vector3 posBam = new Vector3(posStudent.x, posStudent.y+1.15f, posStudent.z);
		bam.transform.localScale = new Vector3 (0.35f, 0.35f, 0);
		return Instantiate (bam,posBam, Quaternion.identity) as GameObject; 

	}
}
