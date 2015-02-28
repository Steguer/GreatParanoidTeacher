using UnityEngine;
using System.Collections;

public class Student : MonoBehaviour {

	
	private Animator animator;

	private bool isClickable = false;
	public float Timer = 1.0f;
	



	
	
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
		if (Timer > 0.0f) {
			Timer-=Time.deltaTime;
		}

		AnimatorStateInfo currentAnimeState = animator.GetCurrentAnimatorStateInfo(0);
		if(currentAnimeState.IsName("StudentIdle"))
			isClickable=true;


		if(currentAnimeState.IsName("StudentCheating"))
		if(isClickable){
			//Debug.Log ("StudentCheating");
		}

		  if(currentAnimeState.IsName("StudentEvilHit"))
		if(isClickable){
			//Augmenter les points ?
			Debug.Log ("StudentEvilHit");
			isClickable=false;
		}

		if(currentAnimeState.IsName("StudentInnocentHit"))
		if(isClickable){
			//Decementer les Points ?
			Debug.Log ("StudentInnocentHit");
			isClickable=false;
		}

	}
}
