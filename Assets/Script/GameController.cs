using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject redPirate;
	public GameObject redTreasure;
	public GameObject bluePirate;
	public GameObject blueTreasure;

	public enum Turn{
		RedTeam,
		BlueTeam,
		Movement,
		Win
	};

	public static Turn lastTurn;

	public static Turn turn;
	public static Board board;

	void Start(){
		board = new Board ();
		if (Random.Range (0, 2) == 0) {
			turn = Turn.RedTeam;
		} else {
			turn = Turn.RedTeam;
		}
		lastTurn = turn;
		prepareBoard ();
	}

	private void prepareBoard(){
		GameObject redFather = GameObject.FindGameObjectWithTag("RedTeam");
		GameObject blueFather = GameObject.FindGameObjectWithTag("BlueTeam");

		if (MainMenu.dpBlue == 0) {
			//Debug.Log ("BlueTeam -> Player");
			blueFather.GetComponent<PlayerController> ().enabled = true;
			blueFather.GetComponent<CompController> ().enabled = false;
		} else {
			//Debug.Log ("BlueTeam -> Com");
			blueFather.GetComponent<PlayerController> ().enabled = false;
			blueFather.GetComponent<CompController> ().enabled = true;
			blueFather.GetComponent<CompController> ().MaxDepth = MainMenu.dpBlue;

		}

		if (MainMenu.dpRed == 0) {
			//Debug.Log ("RedTeam -> Player");
			redFather.GetComponent<PlayerController> ().enabled = true;
			redFather.GetComponent<CompController> ().enabled = false;
		} else {
			//Debug.Log ("RedTeam -> Com");
			redFather.GetComponent<PlayerController> ().enabled = false;
			redFather.GetComponent<CompController> ().enabled = true;
			redFather.GetComponent<CompController> ().MaxDepth = MainMenu.dpRed;
		}

		if (GameController.board != null) {
			GameObject aux;

			aux = Instantiate (redPirate, redFather.transform);
			aux.transform.localPosition = new Vector3( board.RedTeam [0].x, board.RedTeam [0].y, 0);
			aux = Instantiate (redPirate, redFather.transform);
			aux.transform.localPosition = new Vector3( board.RedTeam [1].x, board.RedTeam [1].y, 0);
			aux = Instantiate (redTreasure, redFather.transform);
			aux.transform.localPosition = new Vector3( board.RedTeam [2].x - 0.5f, board.RedTeam [2].y, 0);

			aux = Instantiate (bluePirate, blueFather.transform);
			aux.transform.localPosition = new Vector3( board.BlueTeam [0].x, board.BlueTeam [0].y, 0);
			aux = Instantiate (bluePirate, blueFather.transform);
			aux.transform.localPosition = new Vector3( board.BlueTeam [1].x, board.BlueTeam [1].y, 0);
			aux = Instantiate (blueTreasure, blueFather.transform);
			aux.transform.localPosition = new Vector3( board.BlueTeam [2].x + 0.5f, board.BlueTeam [2].y, 0);
		}
	}

	public static void changeTurn(){
		turn = ((lastTurn == Turn.BlueTeam) ? Turn.RedTeam : Turn.BlueTeam);
		lastTurn = turn;
		verifyWin ();
	}

	private static void verifyWin(){
		if (board.BlueTeam[0].Equals(board.RedTeam[2]) || 
			board.BlueTeam[1].Equals(board.RedTeam[2])){
			turn = Turn.Win;
		}else if (board.RedTeam[0].Equals(board.BlueTeam[2]) || 
			board.RedTeam[1].Equals(board.BlueTeam[2])){
			turn = Turn.Win;
		}
	}

}
