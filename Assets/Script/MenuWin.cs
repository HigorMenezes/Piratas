using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuWin : MonoBehaviour {

	public Canvas canvas;

	private bool flag;

	void Start(){
		flag = true;
	}

	void Update(){
		if (GameController.turn.Equals(GameController.Turn.Win) && flag){
			flag = false;
			Instantiate (canvas);
		}
	}

}
