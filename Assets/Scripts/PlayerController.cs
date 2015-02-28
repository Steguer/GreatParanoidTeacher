﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	//********* Public attributs *********
	public Texture2D cursorTexture;
	public float fireRate = 0.5F;
	public int stressLimit = 10;
	public int playerStress = 0;
	public GameObject objetCraie;

	//********* Private attributs *********
	private float nextFire = 0.0F;
	private CursorMode cursorMode = CursorMode.Auto;
	private Vector2 hotSpot;
	private Vector3 pos;


	// Use this for initialization
	void Start () {
		var tmp = new Vector2(cursorTexture.width/2, cursorTexture.height/2);
		hotSpot = Vector2.zero + tmp;
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
	}
	
	// Update is called once per frame
	void Update () {
		var hit = fire ();
		checkHitState(hit);

		var mousePos = Input.mousePosition;
		mousePos.z = 10; // select distance = 10 units from the camera
		pos = GameObject.Find("Main Camera").camera.ScreenToWorldPoint(mousePos);
		Debug.Log (pos);
		//pos = Input.mousePosition;
		//pos.z = 20f;
		//pos = Camera.main.ScreenToWorldPoint(pos);
		//objetCraie.GetComponent<moveCraie> ().arrivee = pos;

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
			instanciateCraie(null);
		}
		return null;
	}

	/**
	 * Check the state of the hit. Increase stress if it's in StudentIdle state, decrease if it's in StudentCheating state.
	 */
	private void checkHitState(Transform hit) {
		AnimatorStateInfo currentState;
		if(hit != null) {
			currentState = hit.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
			if(currentState.IsName("StudentIdle")) {
				playerStress++;
			}
			else if(currentState.IsName("StudentCheating")) {
				playerStress--;
			}
		}
	}

	private void instanciateCraie(Transform hit) {		
		GameObject cr = Instantiate (objetCraie, Input.mousePosition, Quaternion.identity) as GameObject; 
		cr.GetComponent<moveCraie> ().arrivee = new Vector3(pos.x, pos.y, pos.z);
		Vector3 arm = GameObject.Find ("Main Camera").camera.transform.position;
		cr.GetComponent<moveCraie> ().depart = new Vector3(arm.x+0.4f, arm.y-0.4f,arm.z);

		if(hit != null) {
			cr.GetComponent<moveCraie>().studentTargeted = hit.gameObject;
		}
	}
}
