﻿using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.IO;
//using (var file = File.OpenWrite(path))
using System.Collections;

public class scoreManager : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Button backButton = GameObject.Find ("Btn_Back").GetComponent<Button> ();
		backButton.onClick.AddListener (Btn_BackListener);



		ArrayList list = new ArrayList();
		using (StreamReader reader = new StreamReader("./Assets/Scripts/UI/Scores/scores.txt"))
		{
			string line;
			while ((line = reader.ReadLine()) != null)
			{
				list.Add(line); // Add to list.
			}
		}
		//Change player's text label as his place on the score list
		for (int i=0; i<list.Count; i++) {
			GameObject.Find ("Player"+(i+1)+"").GetComponent<Text> ().text=list[i]+"";
		}

	}

	public void Btn_BackListener(){
		Application.LoadLevel ("testMainMenu");
	}

	// Update is called once per frame
	void Update () {
	
	}
}
