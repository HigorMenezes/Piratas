using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DebugTree {


	public static void imprime(Nodo raiz){

		List<Nodo> childrens = new List<Nodo> ();
		List<Nodo> fathers = new List<Nodo> ();
		int nivel = 0;

		string aux = "";

		fathers.Add (raiz);

		for (int i = 0; i < 6; i ++) {
			aux = "";
			//aux += nivel + "  :";
			nivel++;
			foreach(Nodo father in fathers){

				if (father.Father != null) {
					aux += "  {" + father.Movement.To + " Value: " + father.FUtility +"}  ";
				} else {
					aux += "  " + father.Name;
				}
				childrens.AddRange (father.Children);
			}

			Debug.Log (aux);
			fathers.Clear ();
			fathers.AddRange (childrens);
			childrens.Clear ();

		}

	}

}
