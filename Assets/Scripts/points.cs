using UnityEngine;
using System.Collections;

public class points : MonoBehaviour {

	public Vector3 posDepart;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(0,.04f,0));
	}
}
