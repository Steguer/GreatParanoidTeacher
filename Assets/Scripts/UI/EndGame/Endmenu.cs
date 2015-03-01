using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Endmenu : MonoBehaviour {
	private Button rButton, qButton;
	private AudioSource clickS;
	public AudioClip clickSound;
	public string playLevel = "SceneAlaMain1";
	public string returnMenu = "test_mainMenu";

	// Use this for initialization
	void Start () {
		clickS = gameObject.AddComponent<AudioSource> ();
		clickS.clip = clickSound;

		rButton = GameObject.Find ("Btn_Restart").GetComponent<Button> ();
		qButton = GameObject.Find ("Btn_Quit").GetComponent<Button> ();

		rButton.onClick.AddListener (rButtonListener);
		qButton.onClick.AddListener (qButtonListener);

	
	}

	/**
	 * Listener bouton retry
	 * */
	public void rButtonListener(){
		clickS.Play ();
		Application.LoadLevel (playLevel);
	}
	
	/**
	 * Listener bouton quit (retourner au menu principal)
	 * */
	public void qButtonListener(){
		clickS.Play ();
		Application.LoadLevel (returnMenu);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
