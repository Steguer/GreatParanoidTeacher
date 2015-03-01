using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	//********* Public attributs *********
	public float eventStudentRate = 0.5F;
	public int redGuyEvent = 10;
	public float alphaRate = 0.0001f;

	//********* Private attributs *********
	private float nextStudentEvent = 0.0F;
	private bool enaRedGuy = true;

	public static int Score,NbChalksThrown, NbCheatersTouched;

	// Use this for initialization
	void Start () {
		Score = 0;
		NbChalksThrown = 0;
		NbCheatersTouched = 0;
	}
	
	// Update is called once per frame
	void Update () {
		eventStudents();
		var stress = checkPlayerStess();
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		float stressLimit = player.GetComponent<PlayerController>().stressLimit;

		if (stress >= stressLimit) {
			Application.LoadLevel("gameOverScene");
		}
	}

	/*
	 * Check the player's stress and call the SoundGenerator to change the music according to the stress
	 */
	public float checkPlayerStess() {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		float stressLimit = player.GetComponent<PlayerController>().stressLimit;
		float playerStress = player.GetComponent<PlayerController>().playerStress;
		float stress = playerStress/stressLimit;

		// Display stress to screen
		float transparence = playerStress / stressLimit;
		GameObject img=GameObject.Find ("Image");
		Image temp = img.GetComponent<Image> ();
		Color c = temp.color;

		if(c.a <= transparence) {
			c.a += alphaRate;
		}
		else {
			c.a -= alphaRate;
		}

		temp.color = c;

		return playerStress;
		//GameObject soundGenerator = GameObject.FindGameObjectWithTag("SoundGenerator");
		//soundGenerator.GetComponent<StressBeats>().stressLevel = stress;*/
	}

	void eventStudents() {
		if (Time.time >= nextStudentEvent) {
			GameObject[] students = GameObject.FindGameObjectsWithTag("Student");
			int student = Random.Range(0, students.Length-1);

			nextStudentEvent = Time.time + eventStudentRate;

			GameObject tmp = (GameObject)students.GetValue(student);
			if(student%2 == 1) {
				tmp.GetComponent<Student>().Cheat(true);
			}
			else {
				tmp.GetComponent<Student>().Cheat(false);
			}
		}
	}
}
