using UnityEngine;
using System.Collections;

/**
 * Script pour gérer l'animation de la caméra en fin de partie
 * Utilise le plugin/script iTween
 * */
public class CameraEndGame : MonoBehaviour {
	public GameObject destination;
	public float cameraRotationX, cameraRotationY, cameraRotationZ;
	private float baseRotationX;
	private Vector3 finalRotation;
	public float animationTime;
	bool animationPlaying;
	private GameObject canvas;

	

	// Use this for initialization
	void Start () {



		canvas = GameObject.Find ("Canvas");
		canvas.SetActive (false);
		baseRotationX = transform.rotation.x;
		finalRotation = new Vector3 (cameraRotationX, cameraRotationY, cameraRotationZ);
		Vector3 destPosition = new Vector3 (destination.transform.position.x, transform.position.y, destination.transform.position.z-1);
		iTween.MoveTo (gameObject, destPosition, 4);
		iTween.RotateTo (gameObject, finalRotation, animationTime);
		animationPlaying = true;
		Invoke ("displayGUI", animationTime-1);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void displayGUI()
	{
		canvas.SetActive (true);
		GameObject.Find ("EndGameManager").GetComponent<EndGame> ().playStampSound ();
	}
}
