using UnityEngine;
using System.Collections;

public class Student : MonoBehaviour {

	
	private Animator animator;

	private bool isClickable = false;
	public float Timer;
	


	public float TimerFail;
	private float TimerFailCopy;


	// Use this for initialization
	void Start () {
	
		animator = GetComponent<Animator> ();
	
		TimerFailCopy = TimerFail;
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
		if (TimerFail > 0.0f)
			TimerFail -= Time.deltaTime;
		if(TimerFail<=0.0f)
			animator.SetBool("isFail",true);


		AnimatorStateInfo currentAnimeState = animator.GetCurrentAnimatorStateInfo(0);
		if (currentAnimeState.IsName ("StudentIdle")) {
			isClickable = true;
			animator.SetBool ("isFail", false);
			TimerFail = TimerFailCopy;
		}

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
		if (currentAnimeState.IsName ("StudentSucceed")) {
			//Incrementer le stress
			animator.SetBool("isFail",false);
			
		}

	}
}
