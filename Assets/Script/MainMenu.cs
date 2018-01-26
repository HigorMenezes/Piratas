using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public Dropdown dropDownBlue;
	public Dropdown dropDownRed;

	public static int dpBlue;
	public static int dpRed;

	void Start () {
	}

	void Update () {
	}

	public void Play (){

		dpBlue = dropDownBlue.value;
		dpRed = dropDownRed.value;

		//TreeGenerate.maxDepth = dropDownBlue.value != 0 ? dropDownBlue.value : TreeGenerate.maxDepth;

		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void Quit(){
		Debug.Log ("Quit");
		Application.Quit ();
	}

}
