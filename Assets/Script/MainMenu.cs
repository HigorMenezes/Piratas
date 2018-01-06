using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public Dropdown dropDownBlue;
	public Dropdown dropDownRed;

	public static string dpBlue = "Player";
	public static string dpRed = "Player";

	void Start () {
	}

	void Update () {
	}

	public void Play (){

		dpBlue = (dropDownBlue.value == 0) ? "Player" : "Com";
		dpRed = (dropDownRed.value == 0) ? "Player" : "Com";


		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void Quit(){
		Debug.Log ("Quit");
		Application.Quit ();
	}

}
