using UnityEngine;
using System.Collections;

/**
 * Classe bidon pour envoyer des niveaux de stress au beatMaker quand on clique sur un cube
 * */
public class StressTmp : MonoBehaviour {

	// Use this for initialization
	void Start () {

		//1er cube par defaut
		GameObject.Find ("BeatMaker").GetComponent<StressBeats>().stressLevel = 0.10f ;
		GameObject.Find ("Cube10").renderer.material.color = new Color(255,0,0);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		Debug.Log ("Click on "+gameObject.name);

		//Test : on change le niveau de stress dans le beat maker pour jouer le beat correct
		if (gameObject.name == "Cube10") 
		{
			GameObject.Find ("BeatMaker").GetComponent<StressBeats>().stressLevel = 0.10f ;
			GameObject.Find ("Cube10").renderer.material.color = new Color(255,0,0);
			GameObject.Find ("Cube25").renderer.material.color = new Color(255,255,255);
			GameObject.Find ("Cube50").renderer.material.color = new Color(255,255,255);
			GameObject.Find ("Cube75").renderer.material.color = new Color(255,255,255);
			GameObject.Find ("Cube90").renderer.material.color = new Color(255,255,255);

		}

		else if (gameObject.name == "Cube25") 
		{
			GameObject.Find ("BeatMaker").GetComponent<StressBeats>().stressLevel = 0.25f ;
			GameObject.Find ("Cube10").renderer.material.color = new Color(255,0,0);
			GameObject.Find ("Cube25").renderer.material.color = new Color(255,0,0);
			GameObject.Find ("Cube50").renderer.material.color = new Color(255,255,255);
			GameObject.Find ("Cube75").renderer.material.color = new Color(255,255,255);
			GameObject.Find ("Cube90").renderer.material.color = new Color(255,255,255);

		}

		else if (gameObject.name == "Cube50") 
		{
			GameObject.Find ("BeatMaker").GetComponent<StressBeats>().stressLevel = 0.50f ;
			GameObject.Find ("Cube10").renderer.material.color = new Color(255,0,0);
			GameObject.Find ("Cube25").renderer.material.color = new Color(255,0,0);
			GameObject.Find ("Cube50").renderer.material.color = new Color(255,0,0);
			GameObject.Find ("Cube75").renderer.material.color = new Color(255,255,255);
			GameObject.Find ("Cube90").renderer.material.color = new Color(255,255,255);

		}

		else if (gameObject.name == "Cube75") 
		{
			GameObject.Find ("BeatMaker").GetComponent<StressBeats>().stressLevel = 0.75f ;
			GameObject.Find ("Cube10").renderer.material.color = new Color(255,0,0);
			GameObject.Find ("Cube25").renderer.material.color = new Color(255,0,0);
			GameObject.Find ("Cube50").renderer.material.color = new Color(255,0,0);
			GameObject.Find ("Cube75").renderer.material.color = new Color(255,0,0);
			GameObject.Find ("Cube90").renderer.material.color = new Color(255,255,255);

		}

		else if (gameObject.name == "Cube90") 
		{
			GameObject.Find ("BeatMaker").GetComponent<StressBeats>().stressLevel = 0.90f ;
			GameObject.Find ("Cube10").renderer.material.color = new Color(255,0,0);
			GameObject.Find ("Cube25").renderer.material.color = new Color(255,0,0);
			GameObject.Find ("Cube50").renderer.material.color = new Color(255,0,0);
			GameObject.Find ("Cube75").renderer.material.color = new Color(255,0,0);
			GameObject.Find ("Cube90").renderer.material.color = new Color(255,0,0);

		}


	}
}
