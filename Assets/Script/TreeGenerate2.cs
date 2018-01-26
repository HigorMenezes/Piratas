using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TreeGenerate2 {

	public int maxDepth;
	private Nodo raiz = new Nodo ();
	private string tag;

	public TreeGenerate2 (string tag, int maxDepth)
	{
		this.tag = tag;
		this.raiz.Name = "raiz";
		this.raiz.Board = GameController.board.clone ();
		this.raiz.MaxMin = Nodo.MaxOrMin.Max;
		this.maxDepth = maxDepth > 0 ? maxDepth : 4;
		generate ();
	}

	private void generate(){
		List<Nodo> childrens = new List<Nodo> ();
		List<Nodo> fathers = new List<Nodo> ();
		List<Movement> movements = new List<Movement> ();

		childrens.Clear ();
		fathers.Clear ();
		movements.Clear ();

		fathers.Add (raiz);
		int j = 1;

		for (int i = 0; i < this.maxDepth; i++) {
			foreach (Nodo father in fathers) {

				if (this.tag.Equals ("BlueTeam")) {//A IA esta no time azul

					if (father.MaxMin.Equals (Nodo.MaxOrMin.Max)) {//Verifica se o pai é max, para fazer o movimento da IA

						if (father.Board.BlueTeam [0].x != -10.0f) {//Verifica se o primeiro personagem está em jogo

							movements.AddRange( MovementCalculate.calculate (father.Board, father.Board.BlueTeam [0], "BlueTeam"));

							foreach (Movement movement in movements) {// Para cada movemento será criado um novo nodo filho
								Nodo nodo = new Nodo();

								nodo.Board = father.Board.clone ();
								nodo.Board.BlueTeam [0] = movement.To;

								if (movement.To.Equals (father.Board.RedTeam [0])) {
									nodo.Board.RedTeam [0].x = -10f;
									nodo.Board.RedTeam [0].y = -10f;
								} else if (movement.To.Equals (father.Board.RedTeam [1])) {
									nodo.Board.RedTeam [1].x = -10f;
									nodo.Board.RedTeam [1].y = -10f;
								}

								nodo.Father = father;

								nodo.MaxMin = Nodo.MaxOrMin.Min;

								nodo.Movement = movement;

								nodo.Name = "" + j;
								j++;

								if (movement.To.Equals (GameController.board.RedTeam [2])) {
									nodo.FUtility = 1000;
									Debug.Log (nodo.FUtility);
								}

								father.addChildren (nodo);
							}
							movements.Clear ();
						}

						if (father.Board.BlueTeam [1].x != -10.0f) {//Verifica se o primeiro personagem está em jogo

							movements.AddRange(MovementCalculate.calculate (father.Board, father.Board.BlueTeam [1], "BlueTeam"));

							foreach (Movement movement in movements) {// Para cada movemento será criado um novo nodo filho
								Nodo nodo = new Nodo();

								nodo.Board = father.Board.clone ();
								nodo.Board.BlueTeam [1] = movement.To;

								if (movement.To.Equals (father.Board.RedTeam [0])) {
									nodo.Board.RedTeam [0].x = -10f;
									nodo.Board.RedTeam [0].y = -10f;
								} else if (movement.To.Equals (father.Board.RedTeam [1])) {
									nodo.Board.RedTeam [1].x = -10f;
									nodo.Board.RedTeam [1].y = -10f;
								}

								nodo.Father = father;

								nodo.MaxMin = Nodo.MaxOrMin.Min;

								nodo.Movement = movement;

								nodo.Name = "" + j;
								j++;

								if (movement.To.Equals (GameController.board.RedTeam [2])) {
									nodo.FUtility = 1000;
									Debug.Log (nodo.FUtility);
								}

								father.addChildren (nodo);
							}
							movements.Clear ();
						}

					} else {//Verifica se o pai é min, para fazer o movimento do Player
					
						if (father.Board.RedTeam [0].x != -10.0f) {//Verifica se o primeiro personagem está em jogo

							movements.AddRange( MovementCalculate.calculate (father.Board, father.Board.RedTeam [0], "RedTeam"));

							foreach (Movement movement in movements) {// Para cada movemento será criado um novo nodo filho
								Nodo nodo = new Nodo();

								nodo.Board = father.Board.clone ();
								nodo.Board.RedTeam [0] = movement.To;

								if (movement.To.Equals (father.Board.BlueTeam [0])) {
									nodo.Board.BlueTeam [0].x = -10f;
									nodo.Board.BlueTeam [0].y = -10f;
								} else if (movement.To.Equals (father.Board.BlueTeam [1])) {
									nodo.Board.BlueTeam [1].x = -10f;
									nodo.Board.BlueTeam [1].y = -10f;
								}

								nodo.Father = father;

								nodo.MaxMin = Nodo.MaxOrMin.Max;

								nodo.Movement = movement;

								nodo.Name = "" + j;
								j++;

								if (movement.To.Equals (GameController.board.BlueTeam [2])) {
									nodo.FUtility = -1000;
									Debug.Log (nodo.FUtility);
								}

								father.addChildren (nodo);
							}
							movements.Clear ();
						}

						if (father.Board.RedTeam [1].x != -10.0f) {//Verifica se o primeiro personagem está em jogo

							movements.AddRange( MovementCalculate.calculate (father.Board, father.Board.RedTeam [1], "RedTeam"));

							foreach (Movement movement in movements) {// Para cada movemento será criado um novo nodo filho
								Nodo nodo = new Nodo();

								nodo.Board = father.Board.clone ();
								nodo.Board.RedTeam [1] = movement.To;

								if (movement.To.Equals (father.Board.BlueTeam [0])) {
									nodo.Board.BlueTeam [0].x = -10f;
									nodo.Board.BlueTeam [0].y = -10f;
								} else if (movement.To.Equals (father.Board.BlueTeam [1])) {
									nodo.Board.BlueTeam [1].x = -10f;
									nodo.Board.BlueTeam [1].y = -10f;
								}

								nodo.Father = father;

								nodo.MaxMin = Nodo.MaxOrMin.Max;

								nodo.Movement = movement;

								nodo.Name = "" + j;
								j++;

								if (movement.To.Equals (GameController.board.BlueTeam [2])) {
									nodo.FUtility = -1000;
									Debug.Log (nodo.FUtility);
								}

								father.addChildren (nodo);
							}
							movements.Clear ();
						}

					}

				} else {//A IA esta no time vermelho

					if (father.MaxMin.Equals (Nodo.MaxOrMin.Max)) {//Verifica se o pai é max, para fazer o movimento da IA

						if (father.Board.RedTeam [0].x != -10.0f) {//Verifica se o primeiro personagem está em jogo

							movements.AddRange( MovementCalculate.calculate (father.Board, father.Board.RedTeam [0], "RedTeam"));

							foreach (Movement movement in movements) {// Para cada movemento será criado um novo nodo filho
								Nodo nodo = new Nodo ();

								nodo.Board = father.Board.clone ();
								nodo.Board.RedTeam [0] = movement.To;

								if (movement.To.Equals (father.Board.BlueTeam [0])) {
									nodo.Board.BlueTeam [0].x = -10f;
									nodo.Board.BlueTeam [0].y = -10f;
								} else if (movement.To.Equals (father.Board.BlueTeam [1])) {
									nodo.Board.BlueTeam [1].x = -10f;
									nodo.Board.BlueTeam [1].y = -10f;
								}

								nodo.Father = father;

								nodo.MaxMin = Nodo.MaxOrMin.Min;

								nodo.Movement = movement;

								nodo.Name = "" + j;
								j++;

								if (movement.To.Equals (GameController.board.BlueTeam [2])) {
									nodo.FUtility = 1000;
									Debug.Log (nodo.FUtility);
								}

								father.addChildren (nodo);
							}
							movements.Clear ();
						}

						if (father.Board.RedTeam [1].x != -10.0f) {//Verifica se o primeiro personagem está em jogo

							movements.AddRange( MovementCalculate.calculate (father.Board, father.Board.RedTeam [1], "RedTeam"));

							foreach (Movement movement in movements) {// Para cada movemento será criado um novo nodo filho
								Nodo nodo = new Nodo ();

								nodo.Board = father.Board.clone ();
								nodo.Board.RedTeam [1] = movement.To;

								if (movement.To.Equals (father.Board.BlueTeam [0])) {
									nodo.Board.BlueTeam [0].x = -10f;
									nodo.Board.BlueTeam [0].y = -10f;
								} else if (movement.To.Equals (father.Board.BlueTeam [1])) {
									nodo.Board.BlueTeam [1].x = -10f;
									nodo.Board.BlueTeam [1].y = -10f;
								}

								nodo.Father = father;

								nodo.MaxMin = Nodo.MaxOrMin.Min;

								nodo.Movement = movement;

								nodo.Name = "" + j;
								j++;

								if (movement.To.Equals (GameController.board.BlueTeam [2])) {
									nodo.FUtility = 1000;
									Debug.Log (nodo.FUtility);
								}

								father.addChildren (nodo);
							}
							movements.Clear ();
						}

					} else {//Verifica se o pai é min, para fazer o movimento do Player

						if (father.Board.BlueTeam [0].x != -10.0f) {//Verifica se o primeiro personagem está em jogo

							movements.AddRange( MovementCalculate.calculate (father.Board, father.Board.BlueTeam [0], "BlueTeam"));

							foreach (Movement movement in movements) {// Para cada movemento será criado um novo nodo filho
								Nodo nodo = new Nodo ();

								nodo.Board = father.Board.clone ();
								nodo.Board.BlueTeam [0] = movement.To;

								if (movement.To.Equals (father.Board.RedTeam [0])) {
									nodo.Board.RedTeam [0].x = -10f;
									nodo.Board.RedTeam [0].y = -10f;
								} else if (movement.To.Equals (father.Board.RedTeam [1])) {
									nodo.Board.RedTeam [1].x = -10f;
									nodo.Board.RedTeam [1].y = -10f;
								}

								nodo.Father = father;

								nodo.MaxMin = Nodo.MaxOrMin.Max;

								nodo.Movement = movement;

								nodo.Name = "" + j;
								j++;

								if (movement.To.Equals (GameController.board.RedTeam [2])) {
									nodo.FUtility = -1000;
									Debug.Log (nodo.FUtility);
								}

								father.addChildren (nodo);
							}
							movements.Clear ();
						}

						if (father.Board.BlueTeam [1].x != -10.0f) {//Verifica se o primeiro personagem está em jogo

							movements.AddRange( MovementCalculate.calculate (father.Board, father.Board.BlueTeam [1], "BlueTeam"));

							foreach (Movement movement in movements) {// Para cada movemento será criado um novo nodo filho
								Nodo nodo = new Nodo ();

								nodo.Board = father.Board.clone ();
								nodo.Board.BlueTeam [1] = movement.To;

								if (movement.To.Equals (father.Board.RedTeam [0])) {
									nodo.Board.RedTeam [0].x = -10f;
									nodo.Board.RedTeam [0].y = -10f;
								} else if (movement.To.Equals (father.Board.RedTeam [1])) {
									nodo.Board.RedTeam [1].x = -10f;
									nodo.Board.RedTeam [1].y = -10f;
								}

								nodo.Father = father;

								nodo.MaxMin = Nodo.MaxOrMin.Max;

								nodo.Movement = movement;

								nodo.Name = "" + j;
								j++;

								if (movement.To.Equals (GameController.board.RedTeam [2])) {
									nodo.FUtility = -1000;
									Debug.Log (nodo.FUtility);
								}

								father.addChildren (nodo);
							}
							movements.Clear ();
						}

					}

				}
				childrens.AddRange (father.Children);
			}

			fathers.Clear ();

			foreach (Nodo nodo in childrens){
				if (float.IsNaN(nodo.FUtility)){
					fathers.Add (nodo);
				}
			}
			childrens.Clear ();

		}

		fathers.Clear ();
		fathers.Add (raiz);

		while (fathers.Count > 0) {

			foreach(Nodo father in fathers){
				if (father.Children.Count == 0 && float.IsNaN(father.FUtility)) {
					father.FUtility = father.Board.fUtility (this.tag);
				}

				childrens.AddRange (father.Children);
			}
			fathers.Clear ();
			fathers.AddRange (childrens);
			childrens.Clear ();
		}
		childrens.Clear ();
	}

	public Nodo Raiz {
		get {
			return this.raiz;
		}
		set {
			raiz = value;
		}
	}

	public string Tag {
		get {
			return this.tag;
		}
		set {
			tag = value;
		}
	}

}
