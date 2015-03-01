using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
	
	//********* Public attributs *********
	public int stressLimit = 10;
	public int playerStress = 0;
	public int score = 0;
	public int nbChalksThrown = 0;
	public float fireRate = 0.5F;
	public Texture2D cursorTexture;
	public GameObject objetCraie;
	public GameObject bam;
	public int combo = 1;
	public GameObject bonus;
	public GameObject malus;
	
	//********* Private attributs *********
	private float nextFire = 0.0F;
	private CursorMode cursorMode = CursorMode.Auto;
	private Vector2 hotSpot;
	private Vector3 pos;
	private Animator animator;
	
	
	// Use this for initialization
	void Start () {
		var tmp = new Vector2(cursorTexture.width/2, cursorTexture.height/2);
		hotSpot = Vector2.zero + tmp;
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);

		Vector3 arm = GameObject.Find ("Main Camera").camera.transform.position;
		transform.position = new Vector3(arm.x+2f, arm.y-3f,arm.z+5f);
		transform.Rotate (new Vector3 (0,0, 00));
		animator = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {

		var hit = fire ();
		var mousePos = Input.mousePosition;
		mousePos.z = 10; // select distance = 10 units from the camera
		pos = GameObject.Find("Main Camera").camera.ScreenToWorldPoint(mousePos);
		GameManager.Score = score;
		//Debug.Log (pos);


	}
	
	/** 
	 * Manage when player fire
	 * 
	 * return the transform of the entity touch else return null
	*/ 
	private Transform fire() {
		RaycastHit2D hit;

		// Check if we can fire
		if (Input.GetButton("Fire1") && Time.time >= nextFire) {
			GameObject.Find ("SoundMaker").GetComponent<SoundMaker>().playArmSwing();
			nbChalksThrown++;
			GameManager.NbChalksThrown = nbChalksThrown;
			
			animator.SetTrigger("Throw");

			nextFire = Time.time + fireRate;
			// Ray tracing
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			hit = Physics2D.GetRayIntersection(ray,Mathf.Infinity);
			
			if(hit.collider != null) {
				// Check if hit a student
				if(hit.transform.tag == "Student") {
					instanciateCraie(hit.transform);

					return hit.transform;
				}
			}
			combo = 1;
			instanciateCraie(null);
			//animator.ResetTrigger("Throw");

		}
		return null;
	}
	

	private void instanciateCraie(Transform hit) {		
		GameObject cr = Instantiate (objetCraie, Input.mousePosition, Quaternion.identity) as GameObject; 
		cr.GetComponent<moveCraie> ().arrivee = new Vector3(pos.x, pos.y, pos.z);
		Vector3 arm = GameObject.Find ("Main Camera").camera.transform.position;
		cr.GetComponent<moveCraie> ().depart = new Vector3(arm.x+0.4f, arm.y-0.4f,arm.z);
		
		if(hit != null) {
			cr.GetComponent<moveCraie>().studentTargeted = hit.gameObject;
			cr.GetComponent<moveCraie>().bam = bam;
			cr.GetComponent<moveCraie>().bonus = bonus;
			cr.GetComponent<moveCraie>().malus = malus;
		}
	}
}
