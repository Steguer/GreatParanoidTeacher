using UnityEngine;
using System.Collections;

public class StudentSpam : MonoBehaviour {

	private Animator animator;
	
	private bool isClickable = false;
	// Espace de  temps entre attaque possible
	public float Timer;
	private float TimerCopy;
	public int count;

	public float TimerFail;
	private float TimerFailCopy;
	

	// Use this for initialization
	void Start () {
		
		animator = GetComponent<Animator> ();
		count=animator.GetInteger("HitCount");
		TimerCopy = Timer;
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
		if (Timer > 0.0f) {
			Timer-=Time.deltaTime;
		}
		if(TimerFail<=0.0f)
			animator.SetBool("isFail",true);

		AnimatorStateInfo currentAnimeState = animator.GetCurrentAnimatorStateInfo(0);
		if (currentAnimeState.IsName ("StudentIdle")) {
			isClickable = true;
			count=0;
			animator.SetInteger("HitCount",count);
			animator.SetBool("isFail",false);
			TimerFail=TimerFailCopy;
		}
		
		
		if(currentAnimeState.IsName("StudentSpamMode"))
		if(isClickable && Timer<=0.0f){
			//count++;
			//animator.SetInteger("HitCount",count);
			//Timer=TimerCopy;
			//Debug.Log ("StudentCheating");
		}
		
		if(currentAnimeState.IsName("StudentSpamHit"))
		if(isClickable && Timer<=0.0f){
			count++;
			animator.SetInteger("HitCount",count);
			Debug.Log ("StudentSpamHit");
			Timer=TimerCopy;
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
