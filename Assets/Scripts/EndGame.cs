using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {
	public float note; //note
	public int nbTimesStressed; //nombre de fois qu'on a atteint un stress max (supérieur à combien de % ?)
	public int cheatersKilled; //nombre de tricheurs éliminés
	public int shots; //nombre de projectiles lancés
	private GameObject noteValue, rankValue, cheaterValue, shotsValue, markImage;
	private AudioSource winMusic, winMusicAverage, loseMusic,stampSound;
	public float noteForVictory, noteForNormal; //note "minimale" pour jouer la musique de victoire, et la musique victoire normale

	//Liste des rangs (selon score du joueur)
	public string rankVeryLow,rankLow, rankAverage, rankGood, rankVeryGood, rankPerfect;
	private float veryLowNote = 5, lowNote = 10, avgNote = 12, goodNote = 15, veryGoodNote = 19, perfectNote = 20;

	private int NB_TEX = 5; //nombre d'images pour la note 
	private Sprite[]images;


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
		
		//Affichage de l'image correspondant à la note
		markImage= GameObject.Find ("MarkImage");
		loadImages ();

		//noteValue.GetComponent<Text>().text = note+"/20";
		cheaterValue.GetComponent<Text>().text = cheatersKilled+"";
		shotsValue.GetComponent<Text>().text = shots+"";

		//On affiche le rang du joueur en fonction de son score
		rankValue.GetComponent<Text>().text = calculateRank();

		//Affichage de l'image de la note (A,B,C...)
		if(note <= veryLowNote)
			markImage.GetComponent<Image>().sprite = images[4];

		else if(note > veryLowNote && note < lowNote)
			markImage.GetComponent<Image>().sprite = images[3];

		else if(note >= lowNote && note <= goodNote)
			markImage.GetComponent<Image>().sprite = images[2];

		else if(note > goodNote && note <= veryGoodNote)
			markImage.GetComponent<Image>().sprite = images[1];

		else if(note > veryGoodNote && note <= perfectNote)
			markImage.GetComponent<Image>().sprite = images[0];

		markImage.GetComponent<Image> ().enabled = true;

		//Lecture des musiques

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

	/**
	 * Méthode qui charge les images
	 * */
	void loadImages()
	{
		images = new Sprite[NB_TEX];
		string imgA = "Assets/Ressources/noteA.png";
		string imgB = "Assets/Ressources/noteB.png";
		string imgC = "Assets/Ressources/noteC.png";
		string imgD = "Assets/Ressources/noteD.png";
		string imgF = "Assets/Ressources/noteF.png";

		Sprite texA = (Sprite)Resources.LoadAssetAtPath(imgA, typeof(Sprite));
		Sprite texB = (Sprite)Resources.LoadAssetAtPath(imgB, typeof(Sprite));
		Sprite texC = (Sprite)Resources.LoadAssetAtPath(imgC, typeof(Sprite));
		Sprite texD = (Sprite)Resources.LoadAssetAtPath(imgD, typeof(Sprite));
		Sprite texF = (Sprite)Resources.LoadAssetAtPath(imgF, typeof(Sprite));
		images[0] = texA;
		images[1] = texB;
		images[2] = texC;
		images[3] = texD;
		images[4] = texF;
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
