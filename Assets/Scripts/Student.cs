﻿using UnityEngine;
using System.Collections;

public class Student : MonoBehaviour {

	
	private Animator animator;

	private bool isClickable = false;
	public float Timer;
	


	public float TimerFail;
	private float TimerFailCopy;

	public int EnrageCountHit = 10;



	private int numCheat;




	// Use this for initialization
	void Start () {
	
		animator = GetComponent<Animator> ();
	
		TimerFailCopy = TimerFail;
		//TimerSpamCopy = TimerSpam;
	}

	public void Cheat(bool EnrageMode)
	{
		if (!EnrageMode) {
			animator.SetInteger ("numCheat", Random.Range (1, 3));
		}
		else
		{
			animator.SetInteger ("numCheat", 0);
			animator.SetBool ("Enraged",true);
		}
		animator.SetTrigger ("isCheating");
	}

	public void Hit()
	{

		animator.SetTrigger ("isHit");
		AnimatorStateInfo currentAnimeState = animator.GetCurrentAnimatorStateInfo(0);
		if (currentAnimeState.IsName ("Enrage") | currentAnimeState.IsName ("EnrageHit")) {
			EnrageCountHit--;
			if(EnrageCountHit<=0)
			{
				animator.SetBool("Enrage",false);
				EnrageCountHit=10;
			}
		}

	}
	// Update is called once per frame
	void Update () {
		CheckStates ();

	}

	void CheckStates ()
	{
		if (TimerFail > 0.0f)
			TimerFail -= Time.deltaTime;
		if(TimerFail<=0.0f)
			animator.SetBool("isFail",true);
		
		
		AnimatorStateInfo currentAnimeState = animator.GetCurrentAnimatorStateInfo(0);
		if (currentAnimeState.IsName ("StudentIdle")) {
			isClickable = true;
			animator.SetBool ("isFail", false);
			TimerFail = TimerFailCopy;
			animator.SetBool ("Enraged",false);
		}
		
		if(currentAnimeState.IsName("StudentCheating1") ||currentAnimeState.IsName("StudentCheating2") ||currentAnimeState.IsName("StudentCheating3"))
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
