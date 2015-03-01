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
		if (GameManager.Score <= 1000) {
			note=20;
			rankValue.GetComponent<Text>().text = rankVeryLow;
		} else if (GameManager.Score <= 5000 && GameManager.Score > 1000) {
			note=18;
			rankValue.GetComponent<Text>().text = rankLow;

		}else if (GameManager.Score <= 7500 && GameManager.Score >5000) {
			note=14;
			rankValue.GetComponent<Text>().text = rankAverage;
		}
		else if (GameManager.Score <= 10000 && GameManager.Score > 7500) {
			note=11;
			rankValue.GetComponent<Text>().text = rankGood;
		}
		else if (GameManager.Score <= 15000 && GameManager.Score > 10000) {
			note=9;
			rankValue.GetComponent<Text>().text = rankVeryGood;
		}
		else if (GameManager.Score > 15000) {
			note=4;
			rankValue.GetComponent<Text>().text = rankPerfect;
		}
		//noteValue.GetComponent<Text>().text = note+"/20";
		cheaterValue.GetComponent<Text> ().text = GameManager.NbCheatersTouched+"";
		shotsValue.GetComponent<Text>().text = GameManager.NbChalksThrown+"";

		//Affichage de l'image de la note (A,B,C...) des étudiants
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

		
		//On affiche le rang du joueur en fonction de son score
		//rankValue.GetComponent<Text>().text = calculateRank();

		markImage.GetComponent<Image> ().enabled = true;

		//Lecture des musiques

		//Si la moyenne de la classe > 10 : musique défaite
		if (note > lowNote) {
			loseMusic.Play ();
		}
		//Moyenne de la classe <= 10 && > 5 : musique succès normal
		else if (note <= lowNote && note > veryLowNote) 
		{
			winMusicAverage.Play ();
		} 

		//Moyenne de la classe <= 5 : musique victoire
		else if (note <= veryLowNote) 
		{
			winMusic.Play();
		}
		saveHighScore();
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
		//veryLow = perfectRank, perfectNote = veryLowRank;
		if (note <= veryLowNote)
			return rankPerfect;
		else if (note > veryLowNote && note < lowNote)
			return rankVeryGood;
		else if (note >= lowNote && note <= goodNote)
			return rankGood;
		else if (note > goodNote && note <= veryGoodNote)
			return rankAverage;
		else if (note > veryGoodNote && note < perfectNote)
			return rankLow;
		else if (note >= perfectNote)
			return rankVeryLow;
		else
			return "oops";
	}

	public void playStampSound()
	{
		stampSound.Play ();
	}
	public void saveHighScore(){

		//StreamReader reader = new StreamReader ("./Assets/Scripts/UI/Scores/scores.txt");
		ArrayList list = new ArrayList();
		int i = 0;
		string line;


		/*asset = Resources.Load(FileName + ".txt") as TextAsset;
		writer = new StreamWriter("Resources/" + FileName + ".txt"); // Does this work?
		writer.WriteLine(appendString);*/
		bool highscore = false;
		using (StreamReader reader = new StreamReader("./Assets/Scripts/UI/Scores/scores.txt"))
		{	
			while ((line = reader.ReadLine()) != null)
			{
				Debug.Log (line+" et i="+i);
				if((Convert.ToInt32(line) < GameManager.Score || line==null) && !highscore  ){
					highscore=true;
					list.Add (GameManager.Score+"");
				}
				list.Add(line);
				i++;
			}
			reader.Close ();
		}

		using (StreamWriter writer = new StreamWriter("./Assets/Scripts/UI/Scores/scores.txt")) {
			for (i=0; i<list.Count; i++) {
				writer.WriteLine (list [i]);
			}
			writer.Close ();
		}

	}
}
