using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FunctionsButton : MonoBehaviour {

	public GameObject red;
	public GameObject blue;

	void Start(){

		if (GameController.lastTurn.Equals (GameController.Turn.BlueTeam)) {
			red.SetActive (true);
		} else {
			blue.SetActive (true);
		}

	}

	public void btnMenu(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex - 1);
		Debug.Log ("Menu");
	}

	public void btnAgain(){
		Debug.Log ("Again");
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

}
