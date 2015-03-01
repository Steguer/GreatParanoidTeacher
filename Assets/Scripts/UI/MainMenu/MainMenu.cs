using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	private Button pButton, qButton, sButton, tButton;
	private string playLevel = "SceneAlaMain1", scoreLevel="test_score", tutoLevel ="tuto";
	public AudioClip clickSound, hoverSound, music;
	private AudioSource clickS, hoverS, menuMusic;

	// Use this for initialization
	void Start () {

		clickS = gameObject.AddComponent<AudioSource> ();
		clickS.clip = clickSound;

		hoverS = gameObject.AddComponent<AudioSource> ();
		hoverS.clip = hoverSound;

		menuMusic = gameObject.AddComponent<AudioSource> ();
		menuMusic.clip = music;
		menuMusic.volume = 0.7f;
		menuMusic.Play ();

		pButton = GameObject.Find ("Btn_Play").GetComponent<Button> ();
		qButton = GameObject.Find ("Btn_Quit").GetComponent<Button> ();
		sButton = GameObject.Find ("Btn_Score").GetComponent<Button> ();
		tButton = GameObject.Find ("Btn_Tuto").GetComponent<Button> ();


		pButton.onClick.AddListener (pButtonListener);
		qButton.onClick.AddListener (qButtonListener);
		sButton.onClick.AddListener (sButtonListener);
		tButton.onClick.AddListener (tButtonListener);
	}

	/**
	 * Listener bouton play
	 * */
	public void pButtonListener(){
		clickS.Play ();
		Application.LoadLevel (playLevel);
	}

	/**
	 * Listener bouton quit
	 * */
	public void qButtonListener(){
		clickS.Play ();
		Application.Quit ();
	}

	/**
	 * Listener bouton score
	 * */
	public void sButtonListener(){
		clickS.Play ();
		Application.LoadLevel (scoreLevel);
	}

	/**
	 * Listener bouton tuto
	 * */
	public void tButtonListener(){
		clickS.Play ();
		Application.LoadLevel (tutoLevel);
	}


	// Update is called once per frame
	void Update () {
	
	}
}
