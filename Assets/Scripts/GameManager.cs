using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//********* Public attributs *********
	public float eventStudentRate = 0.5F;

	//********* Private attributs *********
	private float nextStudentEvent = 0.0F;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		checkPlayerStess();
		eventStudents();
	}

	/*
	 * Check the player's stress and call the SoundGenerator to change the music according to the stress
	 */
	void checkPlayerStess() {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		float stressLimit = player.GetComponent<PlayerController>().stressLimit;
		float playerStress = player.GetComponent<PlayerController>().playerStress;
		float stress = playerStress/stressLimit;

		//GameObject soundGenerator = GameObject.FindGameObjectWithTag("SoundGenerator");
		//soundGenerator.GetComponent<StressBeats>().stressLevel = stress;
	}

	void eventStudents() {
		GameObject[] students = GameObject.FindGameObjectsWithTag("Student");
		int student = Random.Range(0, students.Length);
		if (Time.time >= nextStudentEvent) {
			nextStudentEvent = Time.time + eventStudentRate;

			GameObject tmp = (GameObject)students.GetValue(student);
			tmp.GetComponent<Student>().Cheat(false);
		}
	}
}
