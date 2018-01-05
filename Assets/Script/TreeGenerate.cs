﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TreeGenerate {

	private int maxDepth = 4;
	private Nodo raiz = new Nodo ();
	private string tag;

	public TreeGenerate (string tag)
	{
		this.tag = tag;
		this.raiz.Name = "raiz";
		this.raiz.Board = GameController.board.clone ();
		this.raiz.MaxMin = Nodo.MaxOrMin.Max;
		generate ();
	}

	private void generate(){
		List<Nodo> childrens = new List<Nodo> ();
		List<Nodo> fathers = new List<Nodo> ();
		List<Movement> movements = new List<Movement> ();
		fathers.Add (raiz);
		int j = 1;

		for (int i = 0; i < maxDepth; i++) {
			childrens.Clear ();
			foreach(Nodo father in fathers){

				//Debug.Log (father.Name + "  " + father.Board.ToString());

				movements.Clear ();
				if (tag.Equals ("RedTeam")) {
					if (father.MaxMin.Equals (Nodo.MaxOrMin.Max)) {
						if (father.Board.RedTeam [0].x != -10f) {
							movements.AddRange (MovementCalculate.calculate (father.Board.clone(), father.Board.RedTeam [0], "RedTeam"));

							foreach (Movement movement in movements) {
								Nodo aux = new Nodo ();

								aux.Name = "" + j;
								j++;

								aux.Board = father.Board.clone ();
								aux.Board.RedTeam [0] = movement.To;

								if (movement.To.Equals (father.Board.BlueTeam [0])) {
									aux.Board.BlueTeam [0].x = -10f;
									aux.Board.BlueTeam [0].y = -10f;
								} else if (movement.To.Equals (father.Board.BlueTeam [1])) {
									aux.Board.BlueTeam [1].x = -10f;
									aux.Board.BlueTeam [1].y = -10f;
								}

								aux.Father = father;
								aux.MaxMin = Nodo.MaxOrMin.Min;
								aux.Movement = movement;

								if (movement.To.Equals (aux.Board.BlueTeam [2])) {
									aux.FUtility = 1000f;
									//Debug.Log (1000);
								}else
								father.Children.Add (aux);
								childrens.Add (aux);
							}
							movements.Clear ();
						}
						if (father.Board.RedTeam [1].x != -10f) {
							movements.AddRange (MovementCalculate.calculate (father.Board.clone() ,father.Board.RedTeam [1], "RedTeam"));

							foreach (Movement movement in movements) {
								Nodo aux = new Nodo ();

								aux.Name = "" + j;
								j++;

								aux.Board = father.Board.clone ();
								aux.Board.RedTeam [1] = movement.To;

								if (movement.To.Equals (father.Board.BlueTeam [0])) {
									aux.Board.BlueTeam [0].x = -10f;
									aux.Board.BlueTeam [0].y = -10f;
								} else if (movement.To.Equals (father.Board.BlueTeam [1])) {
									aux.Board.BlueTeam [1].x = -10f;
									aux.Board.BlueTeam [1].y = -10f;
								}

								aux.Father = father;
								aux.MaxMin = Nodo.MaxOrMin.Min;
								aux.Movement = movement;

								if (movement.To.Equals (aux.Board.BlueTeam [2])) {
									aux.FUtility = 1000f;
									//Debug.Log (1000);
								}
								father.Children.Add (aux);
								childrens.Add (aux);
							}
							movements.Clear ();
						}
					} else {
						if (father.Board.BlueTeam [0].x != -10f) {
							movements.AddRange (MovementCalculate.calculate (father.Board.clone(), father.Board.BlueTeam [0], "BlueTeam"));

							foreach (Movement movement in movements) {
								Nodo aux = new Nodo ();

								aux.Name = "" + j;
								j++;

								aux.Board = father.Board.clone ();
								aux.Board.BlueTeam [0] = movement.To;

								if (movement.To.Equals (father.Board.RedTeam [0])) {
									aux.Board.RedTeam [0].x = -10f;
									aux.Board.RedTeam [0].y = -10f;
								} else if (movement.To.Equals (father.Board.RedTeam [1])) {
									aux.Board.RedTeam [1].x = -10f;
									aux.Board.RedTeam [1].y = -10f;
								}

								aux.Father = father;
								aux.MaxMin = Nodo.MaxOrMin.Max;
								aux.Movement = movement;

								if (movement.To.Equals (aux.Board.RedTeam [2])) {
									aux.FUtility = -1000f;
									//Debug.Log (-1000);
								}
								father.Children.Add (aux);
								childrens.Add (aux);
							}
							movements.Clear ();
						}
						if (father.Board.BlueTeam [1].x != -10f) {
							movements.AddRange (MovementCalculate.calculate (father.Board.clone(), father.Board.BlueTeam [1], "BlueTeam"));

							foreach (Movement movement in movements) {
								Nodo aux = new Nodo ();

								aux.Name = "" + j;
								j++;

								aux.Board = father.Board.clone ();
								aux.Board.BlueTeam [1] = movement.To;

								if (movement.To.Equals (father.Board.RedTeam [0])) {
									aux.Board.RedTeam [0].x = -10f;
									aux.Board.RedTeam [0].y = -10f;
								} else if (movement.To.Equals (father.Board.RedTeam [1])) {
									aux.Board.RedTeam [1].x = -10f;
									aux.Board.RedTeam [1].y = -10f;
								}

								aux.Father = father;
								aux.MaxMin = Nodo.MaxOrMin.Max;
								aux.Movement = movement;

								if (movement.To.Equals (aux.Board.BlueTeam [2])) {
									aux.FUtility = -1000f;
									//Debug.Log (-1000);
								}
								father.Children.Add (aux);
								childrens.Add (aux);
							}
							movements.Clear ();
						}
					}

				} else {
					if (father.MaxMin.Equals (Nodo.MaxOrMin.Max)) {
						if (father.Board.BlueTeam [0].x != -10f) {
							movements.AddRange (MovementCalculate.calculate (father.Board.clone(), father.Board.BlueTeam [0], "BlueTeam"));

							foreach (Movement movement in movements) {
								Nodo aux = new Nodo ();

								aux.Name = "" + j;
								j++;

								aux.Board = father.Board.clone ();
								aux.Board.BlueTeam [0] = movement.To;

								if (movement.To.Equals (father.Board.RedTeam [0])) {
									aux.Board.RedTeam [0].x = -10f;
									aux.Board.RedTeam [0].y = -10f;
								} else if (movement.To.Equals (father.Board.RedTeam [1])) {
									aux.Board.RedTeam [1].x = -10f;
									aux.Board.RedTeam [1].y = -10f;
								}

								aux.Father = father;
								aux.MaxMin = Nodo.MaxOrMin.Min;
								aux.Movement = movement;

								if (movement.To.Equals (aux.Board.RedTeam [2])) {
									aux.FUtility = 1000f;
									//Debug.Log (1000);
								}
								father.Children.Add (aux);
								childrens.Add (aux);
							}
							movements.Clear ();
						}
						if (father.Board.BlueTeam [1].x != -10f) {
							movements.AddRange (MovementCalculate.calculate (father.Board.clone(), father.Board.BlueTeam [1], "BlueTeam"));

							foreach (Movement movement in movements) {
								Nodo aux = new Nodo ();

								aux.Name = "" + j;
								j++;

								aux.Board = father.Board.clone ();
								aux.Board.BlueTeam [1] = movement.To;

								if (movement.To.Equals (father.Board.RedTeam [0])) {
									aux.Board.RedTeam [0].x = -10f;
									aux.Board.RedTeam [0].y = -10f;
								} else if (movement.To.Equals (father.Board.RedTeam [1])) {
									aux.Board.RedTeam [1].x = -10f;
									aux.Board.RedTeam [1].y = -10f;
								}

								aux.Father = father;
								aux.MaxMin = Nodo.MaxOrMin.Min;
								aux.Movement = movement;

								if (movement.To.Equals (aux.Board.RedTeam [2])) {
									aux.FUtility = 1000f;
									//Debug.Log (1000);
								}
								father.Children.Add (aux);
								childrens.Add (aux);
							}
							movements.Clear ();
						}
					} else {
						if (father.Board.RedTeam [0].x != -10f) {
							movements.AddRange (MovementCalculate.calculate (father.Board.clone(), father.Board.RedTeam [0], "RedTeam"));

							foreach (Movement movement in movements) {
								Nodo aux = new Nodo ();

								aux.Name = "" + j;
								j++;

								aux.Board = father.Board.clone ();
								aux.Board.RedTeam [0] = movement.To;

								if (movement.To.Equals (father.Board.BlueTeam [0])) {
									aux.Board.BlueTeam [0].x = -10f;
									aux.Board.BlueTeam [0].y = -10f;
								} else if (movement.To.Equals (father.Board.BlueTeam [1])) {
									aux.Board.BlueTeam [1].x = -10f;
									aux.Board.BlueTeam [1].y = -10f;
								}

								aux.Father = father;
								aux.MaxMin = Nodo.MaxOrMin.Max;
								aux.Movement = movement;

								if (movement.To.Equals (aux.Board.BlueTeam [2])) {
									aux.FUtility = -1000f;
									//Debug.Log (-1000);
								}
								father.Children.Add (aux);
								childrens.Add (aux);
							}
							movements.Clear ();
						}
						if (father.Board.RedTeam [1].x != -10f) {
							movements.AddRange (MovementCalculate.calculate (father.Board.clone(), father.Board.RedTeam [1], "RedTeam"));

							foreach (Movement movement in movements) {
								Nodo aux = new Nodo ();

								aux.Name = "" + j;
								j++;

								aux.Board = father.Board.clone ();
								aux.Board.RedTeam [1] = movement.To;

								if (movement.To.Equals (father.Board.BlueTeam [0])) {
									aux.Board.BlueTeam [0].x = -10f;
									aux.Board.BlueTeam [0].y = -10f;
								} else if (movement.To.Equals (father.Board.BlueTeam [1])) {
									aux.Board.BlueTeam [1].x = -10f;
									aux.Board.BlueTeam [1].y = -10f;
								}

								aux.Father = father;
								aux.MaxMin = Nodo.MaxOrMin.Max;
								aux.Movement = movement;

								if (movement.To.Equals (aux.Board.BlueTeam [2])) {
									aux.FUtility = -1000f;
									//Debug.Log (-1000);
								}
								father.Children.Add (aux);
								childrens.Add (aux);
							}
							movements.Clear ();
						}
					}
				}

			}

			fathers.Clear ();
			foreach(Nodo children in childrens){
				if (float.IsNaN(children.FUtility)){
					fathers.Add (children);
				}
			}
		}

		fathers.Clear ();
		/*foreach (Nodo children in childrens) {
			if (float.IsNaN (children.FUtility)) {
				children.FUtility = children.Board.fUtility (this.tag);
				//Debug.Log (children.FUtility);
			}
		}*/

		fathers.Add (raiz);

		while (fathers.Count > 0) {
			
			foreach(Nodo father in fathers){

				if (father.Children.Count == 0) {
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

	public int MaxDepth {
		get {
			return this.maxDepth;
		}
		set {
			maxDepth = value;
		}
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
