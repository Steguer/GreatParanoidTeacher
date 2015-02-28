using UnityEngine;
using System.Collections;

public class Student : MonoBehaviour {

	
	private Animator animator;



	// Use this for initialization
	void Start () {
	
		animator = GetComponent<Animator> ();
	}

	public void Cheat()
	{
		animator.SetTrigger ("isCheating");
	}

	public void Hit()
	{
		animator.SetTrigger ("isHit");
	}
	// Update is called once per frame
	void Update () {
	

	}
}
