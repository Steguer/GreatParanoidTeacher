using UnityEngine;
using System.Collections;

/**
 * Script qui permet de jouer des "beats" audio en fonction du niveau de stress
 * */
public class StressBeats : MonoBehaviour {
	private AudioSource beat1, beat2, beat3, beat4, beat5, currentBeat; //fichiers audio et beat actuel
	public float stressLevel; //niveau de stress récupéré (envoyé par le script qui gère le stress)
	private int sLevel1 = 2, sLevel2 = 4, sLevel3 = 6, sLevel4 = 8, sLevel5 = 9; //seuils de niveaux de stress pour jouer la musique
	private bool playBeat;

	// Use this for initialization
	void Start () {

		//Récupération des beats audio
		beat1 = GetComponents<AudioSource> () [0];
		beat2 = GetComponents<AudioSource> () [1];
		beat3 = GetComponents<AudioSource> () [2];
		beat4 = GetComponents<AudioSource> () [3];
		beat5 = GetComponents<AudioSource> () [4];

		currentBeat = beat1;
		playBeat = true;
	
	}
	
	// Update is called once per frame
	void Update () {

		//On recupere le stress level du joueur
		stressLevel = GameObject.Find ("Player").GetComponent<PlayerController>().playerStress;

		playBeat = true;
		//Niveau de stress en dessous du premier seuil : pas de beat
		if (stressLevel < sLevel1) 
		{
			playBeat = false;
		}

		//Premier seuil : premier beat
		else if(stressLevel >= sLevel1 && stressLevel < sLevel2)
		{
			setNewBeat(beat1);
		}

		//2eme seuil
		else if (stressLevel >= sLevel2 && stressLevel < sLevel3)
		{
			setNewBeat(beat2);
		}

		//3eme seuil
		else if (stressLevel >= sLevel3 && stressLevel < sLevel4)
		{
			setNewBeat(beat3);
		}

		//4eme seuil
		else if (stressLevel >= sLevel4 && stressLevel < sLevel5)
		{
			setNewBeat(beat4);
		}

		//5eme seuil
		else if (stressLevel >= sLevel5)
		{
			setNewBeat(beat5);
		}
	
	}

	/**
	 * Methode pour changer le beat à jouer
	 * */
	void setNewBeat(AudioSource beatToPlay)
	{
		if(currentBeat != null)
		{
			if(currentBeat.isPlaying)
			{
				currentBeat.loop = false;
			}
			
			else
			{
				currentBeat = beatToPlay;
				currentBeat.loop = true;
				if(playBeat && !currentBeat.isPlaying)
					currentBeat.Play ();
			}
		}
	}
}
