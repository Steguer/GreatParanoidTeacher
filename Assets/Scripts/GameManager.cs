using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	//********* Public attributs *********
	public float eventStudentRate = 0.5F;
	public int redGuyEvent = 10;

	//********* Private attributs *********
	private float nextStudentEvent = 0.0F;
	private bool enaRedGuy = true;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		checkPlayerStess();
		eventStudents();
		GameObject img=GameObject.Find ("Image");
		Image temp = img.GetComponent<Image> ();
		//temp.color = new Color (temp.color.r, temp.color.g, temp.color.b, temp.color.a + 100);
		Color c = temp.color;
		c.a += 0.001f;
		temp.color = c;
	}

	/*
	 * Check the player's stress and call the SoundGenerator to change the music according to the stress
	 */
	void checkPlayerStess() {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		float stressLimit = player.GetComponent<PlayerController>().stressLimit;
		float playerStress = player.GetComponent<PlayerController>().playerStress;
		float stress = playerStress/stressLimit;

		float transparence = (playerStress * 256) / stressLimit;
		SpriteRenderer sr = GameObject.Find("frame").GetComponent<SpriteRenderer>();
		Color tmp = new Color(190f, 190f, 190f, 256f);
		sr.material.color = tmp;
		//GameObject soundGenerator = GameObject.FindGameObjectWithTag("SoundGenerator");
		//soundGenerator.GetComponent<StressBeats>().stressLevel = stress;
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
