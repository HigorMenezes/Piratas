using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovementCalculate {

	public static List<Movement> calculate(Board b, Vector2 from, string tag){
		List<Movement> movements = new List<Movement> ();
		Board board = b.clone();

		//string enemy = ((tag == "RedTeam") ? "BlueTeam" : tag);
		int player = -1;
		int outherPlayer = -1;

		if (tag.Equals ("BlueTeam")) {
			player = (board.BlueTeam [0].Equals (from)) ? 0 : 1;
			outherPlayer = player == 1 ? 0 : 1;
		} else if (tag.Equals ("RedTeam")) {
			player = (board.RedTeam [0].Equals (from)) ? 0 : 1;
			outherPlayer = player == 1 ? 0 : 1;
		} else {
			Debug.Log ("Erro ao encontrar a tag");
		}

		int maxLine = 7;
		int maxColumn = 5;


		if (tag.Equals ("RedTeam")) {

			if (board.RedTeam[player].x < maxLine && board.RedTeam[player].y + 1 < maxColumn &&
				(board.RedTeam[player].x != board.RedTeam[outherPlayer].x || board.RedTeam[player].y + 1 != board.RedTeam[outherPlayer].y) &&
				(board.RedTeam[player].x != board.BlueTeam[0].x || board.RedTeam[player].y + 1 != board.BlueTeam[0].y) &&
				(board.RedTeam[player].x != board.BlueTeam[1].x || board.RedTeam[player].y + 1 != board.BlueTeam[1].y) &&
				(board.RedTeam[player].x != board.RedTeam[2].x || board.RedTeam[player].y + 1 != board.RedTeam[2].y)){//Direita x | y + 1
				if (new Vector2 (board.RedTeam [player].x, board.RedTeam [player].y + 1).Equals (board.BlueTeam [2])) {
					movements.Add (new Movement (from, new Vector2 (board.RedTeam [player].x, board.RedTeam [player].y + 1), Movement.Move.Win));
				} else {
					movements.Add (new Movement (from, new Vector2 (board.RedTeam [player].x, board.RedTeam [player].y + 1), Movement.Move.Move));
				}
			}
			if (board.RedTeam[player].x < maxLine && board.RedTeam[player].y - 1 >= 0f &&
				(board.RedTeam[player].x != board.RedTeam[outherPlayer].x || board.RedTeam[player].y - 1 != board.RedTeam[outherPlayer].y) &&
				(board.RedTeam[player].x != board.BlueTeam[0].x || board.RedTeam[player].y - 1 != board.BlueTeam[0].y) &&
				(board.RedTeam[player].x != board.BlueTeam[1].x || board.RedTeam[player].y - 1 != board.BlueTeam[1].y) &&
				(board.RedTeam[player].x != board.RedTeam[2].x || board.RedTeam[player].y - 1 != board.RedTeam[2].y)){//Esquerda x | y - 1
				if (new Vector2 (board.RedTeam [player].x, board.RedTeam [player].y - 1).Equals (board.BlueTeam [2])) {
					movements.Add (new Movement (from, new Vector2 (board.RedTeam [player].x, board.RedTeam [player].y - 1), Movement.Move.Win));
				} else {
					movements.Add (new Movement (from, new Vector2 (board.RedTeam [player].x, board.RedTeam [player].y - 1), Movement.Move.Move));
				}
			}
			if (board.RedTeam[player].x + 1 < maxLine && board.RedTeam[player].y < maxColumn &&
				(board.RedTeam[player].x + 1 != board.RedTeam[outherPlayer].x || board.RedTeam[player].y != board.RedTeam[outherPlayer].y) &&
				(board.RedTeam[player].x + 1 != board.BlueTeam[0].x || board.RedTeam[player].y != board.BlueTeam[0].y) &&
				(board.RedTeam[player].x + 1 != board.BlueTeam[1].x || board.RedTeam[player].y != board.BlueTeam[1].y) &&
				(board.RedTeam[player].x + 1 != board.RedTeam[2].x || board.RedTeam[player].y != board.RedTeam[2].y)){//Baixo x + 1 | y
				if (new Vector2 (board.RedTeam [player].x + 1, board.RedTeam [player].y).Equals (board.BlueTeam [2])) {
					movements.Add (new Movement (from, new Vector2 (board.RedTeam [player].x + 1, board.RedTeam [player].y), Movement.Move.Win));
				} else {
					movements.Add (new Movement (from, new Vector2 (board.RedTeam [player].x + 1, board.RedTeam [player].y), Movement.Move.Move));
				}
			}
			if (board.RedTeam[player].x - 1 >= 0f && board.RedTeam[player].y < maxColumn &&
				(board.RedTeam[player].x - 1 != board.RedTeam[outherPlayer].x || board.RedTeam[player].y != board.RedTeam[outherPlayer].y) &&
				(board.RedTeam[player].x - 1 != board.BlueTeam[0].x || board.RedTeam[player].y != board.BlueTeam[0].y) &&
				(board.RedTeam[player].x - 1 != board.BlueTeam[1].x || board.RedTeam[player].y != board.BlueTeam[1].y) &&
				(board.RedTeam[player].x - 1 != board.RedTeam[2].x || board.RedTeam[player].y != board.RedTeam[2].y)){//Cima x - 1 | y
				if (new Vector2 (board.RedTeam [player].x - 1, board.RedTeam [player].y).Equals (board.BlueTeam [2])) {
					movements.Add (new Movement (from, new Vector2 (board.RedTeam [player].x - 1, board.RedTeam [player].y), Movement.Move.Win));
				} else {
					movements.Add (new Movement (from, new Vector2 (board.RedTeam [player].x - 1, board.RedTeam [player].y), Movement.Move.Move));
				}
			}

			if (board.RedTeam[player].x + 1 == board.BlueTeam[0].x && board.RedTeam[player].y + 1 == board.BlueTeam[0].y
				|| board.RedTeam[player].x + 1 == board.BlueTeam[1].x && board.RedTeam[player].y + 1 == board.BlueTeam[1].y){//Direta Baixo x + 1 | y + 1
				movements.Add(new Movement(from, new Vector2(board.RedTeam[player].x + 1, board.RedTeam[player].y + 1), Movement.Move.Attack));
			}
			if (board.RedTeam[player].x + 1 == board.BlueTeam[0].x && board.RedTeam[player].y - 1 == board.BlueTeam[0].y
				|| board.RedTeam[player].x + 1 == board.BlueTeam[1].x && board.RedTeam[player].y - 1 == board.BlueTeam[1].y){//Direta Cima x + 1 | y - 1
				movements.Add(new Movement(from, new Vector2(board.RedTeam[player].x + 1, board.RedTeam[player].y - 1), Movement.Move.Attack));
			}
			if (board.RedTeam[player].x - 1 == board.BlueTeam[0].x && board.RedTeam[player].y + 1 == board.BlueTeam[0].y
				|| board.RedTeam[player].x - 1 == board.BlueTeam[1].x && board.RedTeam[player].y + 1 == board.BlueTeam[1].y){//Esquerda Baixo x - 1 | y + 1
				movements.Add(new Movement(from, new Vector2(board.RedTeam[player].x - 1, board.RedTeam[player].y + 1), Movement.Move.Attack));
			}
			if (board.RedTeam[player].x - 1 == board.BlueTeam[0].x && board.RedTeam[player].y - 1 == board.BlueTeam[0].y
				|| board.RedTeam[player].x - 1 == board.BlueTeam[1].x && board.RedTeam[player].y - 1 == board.BlueTeam[1].y){//Esquerda Cima x - 1 | y - 1
				movements.Add(new Movement(from, new Vector2(board.RedTeam[player].x - 1, board.RedTeam[player].y - 1), Movement.Move.Attack));
			}

		} else {

			if (board.BlueTeam[player].x < maxLine && board.BlueTeam[player].y + 1 < maxColumn &&
				(board.BlueTeam[player].x != board.BlueTeam[outherPlayer].x || board.BlueTeam[player].y + 1 != board.BlueTeam[outherPlayer].y) &&
				(board.BlueTeam[player].x != board.RedTeam[0].x || board.BlueTeam[player].y + 1 != board.RedTeam[0].y) &&
				(board.BlueTeam[player].x != board.RedTeam[1].x || board.BlueTeam[player].y + 1 != board.RedTeam[1].y) &&
				(board.BlueTeam[player].x != board.BlueTeam[2].x || board.BlueTeam[player].y + 1 != board.BlueTeam[2].y)){//Direita x | y + 1
				if (new Vector2 (board.BlueTeam [player].x, board.BlueTeam [player].y + 1).Equals (board.RedTeam [2])) {
					movements.Add (new Movement (from, new Vector2 (board.BlueTeam [player].x, board.BlueTeam [player].y + 1), Movement.Move.Win));
				} else {
					movements.Add (new Movement (from, new Vector2 (board.BlueTeam [player].x, board.BlueTeam [player].y + 1), Movement.Move.Move));
				}
			}
			if (board.BlueTeam[player].x < maxLine && board.BlueTeam[player].y - 1 >= 0f &&
				(board.BlueTeam[player].x != board.BlueTeam[outherPlayer].x || board.BlueTeam[player].y - 1 != board.BlueTeam[outherPlayer].y) &&
				(board.BlueTeam[player].x != board.RedTeam[0].x || board.BlueTeam[player].y - 1 != board.RedTeam[0].y) &&
				(board.BlueTeam[player].x != board.RedTeam[1].x || board.BlueTeam[player].y - 1 != board.RedTeam[1].y) &&
				(board.BlueTeam[player].x != board.BlueTeam[2].x || board.BlueTeam[player].y - 1 != board.BlueTeam[2].y)){//Esquerda x | y - 1
				if (new Vector2 (board.BlueTeam [player].x, board.BlueTeam [player].y - 1).Equals (board.RedTeam [2])) {
					movements.Add (new Movement (from, new Vector2 (board.BlueTeam [player].x, board.BlueTeam [player].y - 1), Movement.Move.Win));
				} else {
					movements.Add (new Movement (from, new Vector2 (board.BlueTeam [player].x, board.BlueTeam [player].y - 1), Movement.Move.Move));
				}
			}
			if (board.BlueTeam[player].x + 1 < maxLine && board.BlueTeam[player].y < maxColumn &&
				(board.BlueTeam[player].x + 1 != board.BlueTeam[outherPlayer].x || board.BlueTeam[player].y != board.BlueTeam[outherPlayer].y) &&
				(board.BlueTeam[player].x + 1 != board.RedTeam[0].x || board.BlueTeam[player].y != board.RedTeam[0].y) &&
				(board.BlueTeam[player].x + 1 != board.RedTeam[1].x || board.BlueTeam[player].y != board.RedTeam[1].y) &&
				(board.BlueTeam[player].x + 1 != board.BlueTeam[2].x || board.BlueTeam[player].y != board.BlueTeam[2].y)){//Baixo x + 1 | y
				if (new Vector2 (board.BlueTeam [player].x + 1, board.BlueTeam [player].y).Equals (board.RedTeam [2])) {
					movements.Add (new Movement (from, new Vector2 (board.BlueTeam [player].x + 1, board.BlueTeam [player].y), Movement.Move.Win));
				} else {
					movements.Add (new Movement (from, new Vector2 (board.BlueTeam [player].x + 1, board.BlueTeam [player].y), Movement.Move.Move));
				}
			}
			if (board.BlueTeam[player].x - 1 >= 0f && board.BlueTeam[player].y < maxColumn &&
				(board.BlueTeam[player].x - 1 != board.BlueTeam[outherPlayer].x || board.BlueTeam[player].y != board.BlueTeam[outherPlayer].y) &&
				(board.BlueTeam[player].x - 1 != board.RedTeam[0].x || board.BlueTeam[player].y != board.RedTeam[0].y) &&
				(board.BlueTeam[player].x - 1 != board.RedTeam[1].x || board.BlueTeam[player].y != board.RedTeam[1].y) &&
				(board.BlueTeam[player].x - 1 != board.BlueTeam[2].x || board.BlueTeam[player].y != board.BlueTeam[2].y)){//Cima x - 1 | y
				if (new Vector2 (board.BlueTeam [player].x - 1, board.BlueTeam [player].y).Equals (board.RedTeam [2])) {
					movements.Add (new Movement (from, new Vector2 (board.BlueTeam [player].x - 1, board.BlueTeam [player].y), Movement.Move.Win));
				} else {
					movements.Add (new Movement (from, new Vector2 (board.BlueTeam [player].x - 1, board.BlueTeam [player].y), Movement.Move.Move));
				}
			}

			if (board.BlueTeam[player].x + 1 == board.RedTeam[0].x && board.BlueTeam[player].y + 1 == board.RedTeam[0].y
				|| board.BlueTeam[player].x + 1 == board.RedTeam[1].x && board.BlueTeam[player].y + 1 == board.RedTeam[1].y){//Direta Baixo x + 1 | y + 1
				movements.Add(new Movement(from, new Vector2(board.BlueTeam[player].x + 1, board.BlueTeam[player].y + 1), Movement.Move.Attack));
			}
			if (board.BlueTeam[player].x + 1 == board.RedTeam[0].x && board.BlueTeam[player].y - 1 == board.RedTeam[0].y
				|| board.BlueTeam[player].x + 1 == board.RedTeam[1].x && board.BlueTeam[player].y - 1 == board.RedTeam[1].y){//Direta Cima x + 1 | y - 1
				movements.Add(new Movement(from, new Vector2(board.BlueTeam[player].x + 1, board.BlueTeam[player].y - 1), Movement.Move.Attack));
			}
			if (board.BlueTeam[player].x - 1 == board.RedTeam[0].x && board.BlueTeam[player].y + 1 == board.RedTeam[0].y
				|| board.BlueTeam[player].x - 1 == board.RedTeam[1].x && board.BlueTeam[player].y + 1 == board.RedTeam[1].y){//Esquerda Baixo x - 1 | y + 1
				movements.Add(new Movement(from, new Vector2(board.BlueTeam[player].x - 1, board.BlueTeam[player].y + 1), Movement.Move.Attack));
			}
			if (board.BlueTeam[player].x - 1 == board.RedTeam[0].x && board.BlueTeam[player].y - 1 == board.RedTeam[0].y
				|| board.BlueTeam[player].x - 1 == board.RedTeam[1].x && board.BlueTeam[player].y - 1 == board.RedTeam[1].y){//Esquerda Cima x - 1 | y - 1
				movements.Add(new Movement(from, new Vector2(board.BlueTeam[player].x - 1, board.BlueTeam[player].y - 1), Movement.Move.Attack));
			}

		}

		return movements;

	}

}
