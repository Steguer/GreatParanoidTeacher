using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		checkPlayerStess();
	}

	/*
	 * Check the player's stress and call the SoundGenerator to change the music according to the stress
	 */
	void checkPlayerStess() {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		float stressLimit = player.GetComponent<PlayerController>().stressLimit;
		float playerStress = player.GetComponent<PlayerController>().playerStress;
		float stress = playerStress/stressLimit;

		GameObject soundGenerator = GameObject.FindGameObjectWithTag("SoundGenerator");
		soundGenerator.GetComponent<StressBeats>().stressLevel = stress;
	}
}
