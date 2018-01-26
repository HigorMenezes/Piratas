using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompController : MonoBehaviour {

	public int maxDepth;

	void Update () {
		if (GameController.turn.ToString().Equals (this.tag)) {

			//Debug.Log (this.tag);

			GameController.turn = GameController.Turn.Movement;
			TreeGenerate2 tree = new TreeGenerate2 (this.tag, maxDepth);

			//DebugTree.imprime (tree.Raiz);

			float fUtility = MiniMax.seach (tree.Raiz);

			//Debug.Log (this.tag + "  " + fUtility);
			int choiceWin = -1;
			int choiceAttack = -1;
			List<Movement> movements = new List<Movement> ();
			foreach(Nodo nodo in tree.Raiz.Children){
				if (nodo.FUtility == fUtility) {
					Debug.Log (nodo.Movement.To);
					movements.Add (nodo.Movement);
					if (nodo.Movement.MoveType.Equals (Movement.Move.Attack)) {
						choiceAttack = movements.Count - 1;
					}else if (nodo.Movement.MoveType.Equals (Movement.Move.Win)) {
						choiceWin = movements.Count - 1;
					}
				}
			}



			if (movements.Count != 0) {
				Debug.Log ("Escolha: " + this.tag + "  " + fUtility);
				if (choiceAttack == -1 && choiceWin == -1) {
					MakeMovement.move (movements [Random.Range (0, movements.Count)], this.tag);
				} else if (choiceWin != -1) {
					MakeMovement.move (movements [choiceWin], this.tag);
				} else {
					MakeMovement.move (movements [choiceAttack], this.tag);
				}

			} else {
				GameController.changeTurn ();
			}


		}

	}


	public int MaxDepth {
		get {
			return this.maxDepth;
		}
		set {
			maxDepth = value;
		}
	}
}
