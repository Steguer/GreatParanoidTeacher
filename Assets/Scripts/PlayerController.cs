﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//********* Public attributs *********
	public Texture2D cursorTexture;
	public float fireRate = 0.5F;
	public int StressLimit = 10;

	//********* Private attributs *********
	private float nextFire = 0.0F;
	private CursorMode cursorMode = CursorMode.Auto;
	private Vector2 hotSpot = Vector2.zero;

	// Use this for initialization
	void Start () {
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
	}
	
	// Update is called once per frame
	void Update () {
		var hit = fire ();

	}

	/** 
	 * Manage when player fire
	 * 
	 * return the transform of the entity touch else return null
	*/ 
	private Transform fire() {
		RaycastHit2D hit;
		// Check if we can fire
		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			// Ray tracing
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			hit = Physics2D.GetRayIntersection(ray,Mathf.Infinity);
			if(hit.collider != null) {
				// Check if hit a student
				if(hit.transform.tag == "Student") {
					hit.transform.GetComponent<Student>().Hit();
					return hit.transform;
				}
			}
		}
		return null;
	}
}
