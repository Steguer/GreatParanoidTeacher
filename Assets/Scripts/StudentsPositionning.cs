using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Classe permettant de générer les élèves à des emplacements donnés (aléatoirement)
 * */
public class StudentsPositionning : MonoBehaviour {

	public List<GameObject> studentPositions; //Liste des positions (tables) des étudiants
	private List<GameObject> students; //liste des étudiants actuellement places
	private List<int> positionsTaken; //liste des positions déjà occupées
	public GameObject positionPrefab; //prefab pour la position des etudiants
	public List<GameObject> studentsPrefabs;// object racine qui doit contenir les gameObjects (prefabs) à utiliser
	public int nbRows, nbCols; //Nombre de lignes/colonnes pour placer des tables
	public GameObject startPoint; //GameObject sert de point de départ pour générer les positions des étudiants
	public float rowDist, colDist; //distance entre deux emplacements sur une ligne, sur une colonne
	private bool randomPositionning;
	

	public int minStudents; //nombre d'étudiants spawnables minimum et maximum
	public int nbStudents; //Nombre d'étudiants (aléatoire)

	// Use this for initialization
	void Start () {


		/** Génération aléatoire des positions ("tables") pour les étudiants **/
		studentPositions = new List<GameObject> ();
		randomPositionning = true;

		//Distances de départ par rapport à la position du teacher
		float currentRowDist = startPoint.transform.position.z + rowDist;
		float currentColDist = startPoint.transform.position.x + colDist;

		for (int i=0; i<nbRows; i++) 
		{
			for (int j=0; j<nbCols; j++) 
			{
				GameObject newPosition = Instantiate (positionPrefab) as GameObject;
				newPosition.transform.position = new Vector3(currentColDist,0,currentRowDist);
				newPosition.name = "pos "+i+","+j;
				studentPositions.Add (newPosition);
				currentColDist+=colDist;
			}

			currentRowDist+=rowDist;
			currentColDist = startPoint.transform.position.x + colDist;
		}




		/** Génération aléatoire des étudiants **/
		positionsTaken = new List<int> ();		
		students = new List<GameObject> ();

		//TEST : ce sera aléatoire à la fin
		if (nbStudents == 0) 
		{
			nbStudents = Random.Range (minStudents, studentPositions.Count); //choix aléatoire du nombre d'étudiants
		}
			

		if(nbStudents > studentPositions.Count-1)
		{
			Debug.Log("Nombre d'étudiants trop grand !!");
			randomPositionning = false;
		}

		Debug.Log ("Nombre d'etudiants a placer : " + nbStudents);



		//Si le nombre d'étudiants est trop important, on remplit toutes les positions directement
		if (!randomPositionning) 
		{
			for(int i=0;i<studentPositions.Count;i++)
			{
				positionsTaken.Add (i);
				studentPositions[i].renderer.material.color= new Color(255,0,0);
			}
		}

		//Sinon on remplit aléatoirement les positions
		else
		{
			int[] randomPositions= new int[nbStudents]; //tableau contenant les positions aléatoires des étudiants

			//Choix des positions aléatoires des étudiants
			for (int i=0; i<nbStudents; i++) 
			{
				//Index aléatoire
				int randomIndex = Random.Range(0,studentPositions.Count-1);
				
				//Tant que la position choisie aléatoirement a déjà été prise, on en choisit une autre
				while(positionsTaken.Contains(randomIndex))
				{
					randomIndex = Random.Range(0,studentPositions.Count-1);
				}
				
				
				//On ajoute la position choisie dans la liste des positions prises
				if(!positionsTaken.Contains(randomIndex))
				{
					positionsTaken.Add (randomIndex);
					
					//TEST
					studentPositions[randomIndex].renderer.material.color= new Color(255,0,0);
					Debug.Log ("Position "+randomIndex+" choisie");
				}
			}
		}


		//Spawn des étudiants aux positions choisies
		for (int i=0; i<positionsTaken.Count; i++) 
		{
			Debug.Log ("prise : "+studentPositions[positionsTaken[i]].name);
			int randomStudentType = Random.Range (0,studentsPrefabs.Count-1);
			GameObject studientClone = Instantiate(studentsPrefabs[randomStudentType], studentPositions[i].transform.position,Quaternion.identity) as GameObject;

			//studientClone.transform.parent = studentPositions[i].transform;
			studientClone.transform.position =  studentPositions[positionsTaken[i]].transform.position;
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
