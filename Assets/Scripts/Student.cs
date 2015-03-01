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
	private BoxCollider2D Cp;
	private CircleCollider2D C2D;

	// Use this for initialization
	void Start () {
	
		Cp =GetComponent<BoxCollider2D>();
		C2D = GetComponent<CircleCollider2D> ();
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
			FixCollision2DEnrageBoy();
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
			ResetCollider2DEnrageBoy();
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
			GameManager.NbCheatersTouched++;
			var temp = playerReference.GetComponent<PlayerController>().playerStress;
			if(temp - decrementStress < 0) {
				GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().playerStress = 0;
			}
			else {
				GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().playerStress -= decrementStress;
			}

			if(GameManager.eventStudentRate - GameManager.speedUp < 0.1f) {
				GameManager.eventStudentRate = 0.1f;
			}
			else {
				GameManager.eventStudentRate -= GameManager.speedUp;
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

	void FixCollision2DEnrageBoy()
	{
		if(isMale)
		{
		BoxCollider2D bx2D = GetComponent<BoxCollider2D>();
		bx2D.center = new Vector2 (0.2f,0f);
		bx2D.size = new Vector2 (1f,2.2f);
		CircleCollider2D c=GetComponent<CircleCollider2D>();
		c.center= new Vector2(0.3f,1.5f);
		c.radius=0.5f;
		}
	}
	void ResetCollider2DEnrageBoy()
	{
		if (isMale) {
			BoxCollider2D bx2D = GetComponent<BoxCollider2D> ();
			bx2D = Cp;
			CircleCollider2D c = GetComponent<CircleCollider2D> ();
			c = C2D;
		}
	}
}
