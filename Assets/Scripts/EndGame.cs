using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {
	public float note; //note
	public int nbTimesStressed; //nombre de fois qu'on a atteint un stress max (supérieur à combien de % ?)
	public int cheatersKilled; //nombre de tricheurs éliminés
	public int shots; //nombre de projectiles lancés
	private GameObject noteValue, rankValue, cheaterValue, shotsValue;
	private AudioSource winMusic, winMusicAverage, loseMusic,stampSound;
	public float noteForVictory, noteForNormal; //note "minimale" pour jouer la musique de victoire, et la musique victoire normale

	//Liste des rangs (selon score du joueur)
	public string rankVeryLow,rankLow, rankAverage, rankGood, rankVeryGood, rankPerfect;
	private float veryLowNote = 5, lowNote = 10, avgNote = 12, goodNote = 15, veryGoodNote = 19, perfectNote = 20;


	// Use this for initialization
	void Start () {
		winMusic = GetComponents<AudioSource> () [0];
		winMusicAverage = GetComponents<AudioSource> () [1];
		loseMusic = GetComponents<AudioSource> () [2];
		stampSound = GetComponents<AudioSource> () [3];

		noteValue = GameObject.Find ("NoteValue");
		rankValue = GameObject.Find ("RankValue");
		cheaterValue = GameObject.Find ("CheaterValue");
		shotsValue = GameObject.Find ("ShotsValue");

		noteValue.GetComponent<Text>().text = note+"/20";
		cheaterValue.GetComponent<Text>().text = cheatersKilled+"";
		shotsValue.GetComponent<Text>().text = shots+"";

		//On affiche le rang du joueur en fonction de son score
		rankValue.GetComponent<Text>().text = calculateRank();


		if (note < noteForNormal) {
			loseMusic.Play ();
		}
		//On joue la musique de victoire si on est au dessus d'une certaine note
		else if (note >= noteForNormal && note < noteForVictory) 
		{
			winMusicAverage.Play ();
		} 
		else if (note >= noteForVictory) 
		{
			winMusic.Play();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/**
	 * Calcul du rang du joueur selon son score, ses kills...
	 * */
	string calculateRank()
	{
		if (note > 0 && note <= veryLowNote)
			return rankVeryLow;
		else if (note > veryLowNote && note <= lowNote)
			return rankLow;
		else if (note > lowNote && note <= avgNote) 
			return rankAverage;
		else if (note > avgNote && note <= goodNote)
			return rankGood;
		else if (note > goodNote && note <= veryGoodNote)
			return rankVeryGood;
		else if (note > veryGoodNote && note <= perfectNote)
			return rankPerfect;
		else
			return "oops!";
	}

	public void playStampSound()
	{
		stampSound.Play ();
	}
}
