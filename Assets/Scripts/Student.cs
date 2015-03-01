using UnityEngine;
using System.Collections;

public class Student : MonoBehaviour {

	//********* Public attributs *********
	public int EnrageCountHit = 4;
	public int incrementStress = 2;
	public int decrementStress = 1;
	public int incrementScore = 200;
	public int decrementScore = 100;
	public float TimerFail;
	public float Timer;
	
	//********* Private attributs *********
	public Animator animator;
	private bool isClickable = false;
	private float TimerFailCopy;
	private int numCheat;
	private bool enaStress = true;

	public bool isLeftAnimationDisabled = false;

	public bool isMale;


	// Use this for initialization
	void Start () {
	
		animator = GetComponent<Animator> ();
	
		TimerFailCopy = TimerFail;
		//TimerSpamCopy = TimerSpam;
	}

	public void Cheat(bool EnrageMode)
	{
		if (!EnrageMode) {
			int i;
			do
			{
				i= Random.Range (1,4);
			}
			while(isLeftAnimationDisabled==true && i==1);
			animator.SetInteger ("numCheat", i);
			animator.SetTrigger ("isCheating");
		}
		else
		{ 
			ModifCollider2DEnrageMode();
			animator.SetBool ("EnrageFinished", false);
			animator.SetTrigger ("Enraged");
		}

	}

	public void Hit()
	{
		GameObject.Find ("SoundMaker").GetComponent<SoundMaker> ().playRandomHurtSound (gameObject);
		animator.SetTrigger ("isHit");
		AnimatorStateInfo currentAnimeState = animator.GetCurrentAnimatorStateInfo(0);
		if (currentAnimeState.IsName ("Enrage") || currentAnimeState.IsName ("EnrageHit")) {
			EnrageCountHit--;
			if(EnrageCountHit<=0)
			{
				animator.SetBool("EnrageFinished",true);
				EnrageCountHit=4;
				ResetCollider2D();
			}
		}

	}
	// Update is called once per frame
	void Update () {
		CheckStates ();

	}

	void CheckStates ()
	{
		GameObject playerReference = GameObject.FindGameObjectWithTag ("Player");
		if (TimerFail > 0.0f)
			TimerFail -= Time.deltaTime;
		if(TimerFail<=0.0f)
			animator.SetBool("isFail",true);
		
		
		AnimatorStateInfo currentAnimeState = animator.GetCurrentAnimatorStateInfo(0);
		if (currentAnimeState.IsName ("StudentIdle")) {
			ResetCollider2D();
			isClickable = true;
			enaStress = true;
			animator.SetBool ("isFail", false);
			TimerFail = TimerFailCopy;
			animator.SetBool ("Enraged",false);
			CircleCollider2D c=GetComponent<CircleCollider2D>();
			c.center= new Vector2(0f,c.center.y);
		}
		
		if(currentAnimeState.IsName("StudentCheating2") )
		if(isClickable){
			CircleCollider2D c=GetComponent<CircleCollider2D>();
			c.center= new Vector2(0.5f,c.center.y);
		}
		
		if(currentAnimeState.IsName("StudentEvilHit"))
		if(isClickable){
			//Augmenter les points ?
			playerReference.GetComponent<PlayerController>().score += incrementScore * playerReference.GetComponent<PlayerController>().combo;
			playerReference.GetComponent<PlayerController>().combo++;
			var temp = playerReference.GetComponent<PlayerController>().playerStress;
			if(temp - decrementStress < 0) {
				GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().playerStress = 0;
			}
			else {
				GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().playerStress -= decrementStress;
			}

			float eventRate = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>().eventStudentRate;
			float speedUp = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>().eventSpeedUp;
			if(eventRate - speedUp < 0.1) {
				GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>().eventStudentRate = 0.1f;
			}
			else {
				GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>().eventStudentRate -= speedUp;
			}

			Debug.Log ("StudentEvilHit");
			isClickable=false;
		}
		
		if(currentAnimeState.IsName("StudentInnocentHit"))
		if(isClickable){
			//Decementer les Points ?
			var tmp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().score;
			if(tmp - decrementScore < 0) {
				GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().score = 0;
			}
			else {
				GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().score -= decrementScore;
			}
			playerReference.GetComponent<PlayerController>().combo = 1;
			Debug.Log ("StudentInnocentHit");
			isClickable=false;
		}
		if (currentAnimeState.IsName ("StudentSucceed")) {
			//Incrementer le stress
			if(enaStress) {
				playerReference.GetComponent<PlayerController>().playerStress += incrementStress;
				playerReference.GetComponent<PlayerController>().combo = 1;
				if(playerReference.GetComponent<PlayerController>().playerStress > playerReference.GetComponent<PlayerController>().stressLimit)
				{
					//Si le stress dépasse la limite on le met à la limite
					playerReference.GetComponent<PlayerController>().playerStress = playerReference.GetComponent<PlayerController>().stressLimit;
				}

				enaStress = false;
			}
			animator.SetBool("isFail",false);
			
		}

	}
	void ModifCollider2DEnrageMode()
	{
		AnimatorStateInfo currentAnimeState = animator.GetCurrentAnimatorStateInfo(0);
		if ( isMale) {
			CircleCollider2D c = GetComponent<CircleCollider2D> ();
			c.center = new Vector2 (0.3f, 1.5f);
			c.radius = 0.5f;

			BoxCollider2D bx2D = GetComponent<BoxCollider2D> ();
			bx2D.size = new Vector2 (1.0f, 2.2f);
			bx2D.center = new Vector2 (0.2f, 0f);
		} 
}
	void ResetCollider2D()
	{
		AnimatorStateInfo currentAnimeState = animator.GetCurrentAnimatorStateInfo(0);
		if (isMale) {
			CircleCollider2D c = GetComponent<CircleCollider2D> ();
			c.center = new Vector2 (0f, 1.1f);
			c.radius = 0.4f;
			
			BoxCollider2D bx2D = GetComponent<BoxCollider2D> ();
			bx2D.size = new Vector2 (1.0f, 2f);
			bx2D.center = new Vector2 (0.2f, -0.3f);
		}

	}
}
