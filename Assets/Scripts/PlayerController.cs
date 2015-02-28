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
	private RaycastHit2D hit;

	// Use this for initialization
	void Start () {
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Trigger when we click with the mouse
	void OnMouseDown () {
		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			if(Physics2D.Raycast(this.transform.position, Vector3.forward, hit)) {
				hit.transform.GetComponent<>
			}
		}
	}
}
