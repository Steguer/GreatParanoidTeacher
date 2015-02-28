using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundMaker : MonoBehaviour {
	public List<AudioClip> hurtSounds; //liste des voix pour les étudiants touchés
	public AudioClip armswing;

	// Use this for initialization
	void Start () {
	
	}

	/**
	 * Jouer une voix au hasard lorsqu'un étudiant est touché
	 * */
	public void playRandomHurtSound(GameObject student)
	{
		int randIndex = Random.Range (0, hurtSounds.Count);
		AudioSource sound = student.AddComponent<AudioSource> ();

		sound.clip = hurtSounds [randIndex];

		if (!student.GetComponent<Student>().isMale) 
		{
			sound.pitch +=0.3f;
		}

		sound.Play ();
			
	}

	public void playArmSwing()
	{
		AudioSource sound = gameObject.AddComponent<AudioSource> ();
		sound.clip = armswing;
		sound.volume = 0.3f;
		sound.Play ();
		Invoke ("removeCurrentAudioSource", 0.5f);
	}

	void removeCurrentAudioSource()
	{
		Destroy(gameObject.GetComponent<AudioSource>());
	}
	// Update is called once per frame
	void Update () {
	
	}
}
