using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutoScript : MonoBehaviour {
	
	private Button pButton, bButton;
	public string playLevel = "SceneAlaMain1";
	public string backLevel = "testMainMenu";
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
		bButton = GameObject.Find ("Btn_Back").GetComponent<Button> ();


		pButton.onClick.AddListener (pButtonListener);
		bButton.onClick.AddListener (bButtonListener);
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
	public void bButtonListener(){
		clickS.Play ();
		Application.LoadLevel (backLevel);
	}


	// Update is called once per frame
	void Update () {
	
	}
}
