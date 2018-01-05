using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompController : MonoBehaviour {


	void Start () {
		
	}

	void Update () {
		if (GameController.turn.ToString().Equals (this.tag)) {

			//Debug.Log (this.tag);

			GameController.turn = GameController.Turn.Movement;
			TreeGenerate tree = new TreeGenerate (this.tag);
			//DebugTree.imprime (tree.Raiz);
			float fUtility = MiniMax.seach (tree.Raiz);

			//Debug.Log (this.tag + "  " + fUtility);

			List<Movement> movements = new List<Movement> ();
			foreach(Nodo nodo in tree.Raiz.Children){
				if (nodo.FUtility == fUtility) {
					//Debug.Log ("Nos escolhidos: " + nodo.Name);
					movements.Add (nodo.Movement);
				}
			}



			if (movements.Count != 0) {
				//Debug.Log ("Escolha: " + this.tag + "  " + fUtility);
				MakeMovement.move (movements [Random.Range (0, movements.Count)], this.tag);
			} else {
				GameController.changeTurn ();
			}


		}

	}
}
