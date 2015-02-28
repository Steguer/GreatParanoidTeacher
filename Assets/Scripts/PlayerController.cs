using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//********* Public attributs *********
	public Texture2D cursorTexture;
	public float fireRate = 0.5F;

	//********* Private attributs *********
	private float nextFire = 0.0F;
	private CursorMode cursorMode = CursorMode.Auto;
	private Vector2 hotSpot = Vector2.zero;
	private RaycastHit hit;

	// Use this for initialization
	void Start () {
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Trigger when we click with the mouse
	void OnMouseDown () {
		// Check if we can fire
		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			// Ray tracing
			if(Physics.Raycast(this.transform.position, Vector3.forward, out hit)) {
				// Check if hit a student
				if(hit.transform.tag == "Student") {
					hit.transform.GetComponent<Student>().Hit();
				}
			}
		}
	}
}
