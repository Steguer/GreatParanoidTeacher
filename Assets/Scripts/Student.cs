﻿using UnityEngine;
using System.Collections;

public class Student : MonoBehaviour {

	

	public float Timer;
	public int EnrageCountHit = 10;
	public float TimerFail;
	public int incrementStress = 1;
	

	private Animator animator;
	private bool isClickable = false;
	private float TimerFailCopy;
	private int numCheat;
	private bool enaStress = true;




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
			enaStress = true;
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
			if(enaStress) {
				GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().playerStress += incrementStress;
				enaStress = false;
			}
			animator.SetBool("isFail",false);
			
		}

	}
}
