using UnityEngine;
using System.Collections;

public class aiguille : MonoBehaviour {

	public int x;
	public int y;
	public float time_up;//en sec, temp pour faire un tour
	public GameObject perfab;
	private float angle;


	// Use this for initialization
	void Start () {

		angle=360/time_up;
		//perfab.transform.position = new Vector3(0	, 0, 0);
		InvokeRepeating("rotationAiguille", 0, 1.0f);
		perfab.transform.Rotate( new Vector3(0, 0, -angle));
	}


	void Update () {
	}

	void rotationAiguille(){
		perfab.transform.Rotate( new Vector3(0, 0, angle));
	}


}