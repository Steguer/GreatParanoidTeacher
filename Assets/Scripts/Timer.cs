using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {
	public float minutes, seconds; //durée de la partie
	private float milliseconds;
	private bool runTimer;

	// Use this for initialization
	void Start () {
		runTimer = true;
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		//Temps écoulé : fin de la partie
		if (runTimer && minutes <= 0 && seconds <= 0 && milliseconds <= 0) 
		{
			runTimer = false;
			onTimerEnd();
		}
		
		if (milliseconds <= 0) 
		{
			if (seconds <= 0) 
			{
				minutes--;
				seconds = 59;
				
			}
			
			else if(seconds >= 1)
			{
				seconds--;
			}
			
			milliseconds = 100;
			
		}
		
		milliseconds -= Time.deltaTime * 100;
		
		if (runTimer) 
		{
			if (seconds < 10) 
			{
				Text t = this.GetComponent<Text>();
				t.text = string.Format ("{0}:0{1}", minutes, seconds);
			}
			
			else
			{
				Text t = this.GetComponent<Text>();
				t.text = string.Format ("{0}:{1}", minutes, seconds);
			}
				
		}
	}

	/**
	 * Methode appelée lorsque le temps est écoulé
	 * */
	void onTimerEnd()
	{
		Debug.Log ("Temps Ecoule");
	}

}
