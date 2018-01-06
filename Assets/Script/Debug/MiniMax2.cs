using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MiniMax2 {

	public static float seach(Nodo raiz){

		List<Nodo> stack = new List<Nodo> ();
		Nodo currentNode = raiz;

		for (int i = 0; i < 400; i++){
			Debug.Log("1Visitou o " + currentNode.Name);
			if (float.IsNaN (currentNode.FUtility)) {

				foreach (Nodo nodo in currentNode.Children) {
					nodo.Father = currentNode;
					stack.Add (nodo);
				}

			} else {
				float fUtility = currentNode.FUtility;
				Nodo father = currentNode.Father;
				Nodo ancestral;

				if (father != null) {
					if (float.IsNaN (father.FUtility)) {
						father.FUtility = fUtility;
						Debug.Log("2Setou o valor para " + fUtility + " o " + father.Name);
					} else if (father.MaxMin.Equals (Nodo.MaxOrMin.Max)) {
						if (fUtility > father.FUtility) {
							father.FUtility = fUtility;
							Debug.Log("3Setou o valor para " + fUtility + " o " + father.Name);
						}
					} else if (father.MaxMin.Equals (Nodo.MaxOrMin.Min)) {
						if (fUtility < father.FUtility) {
							father.FUtility = fUtility;
							Debug.Log("4Setou o valor para " + fUtility + " o " + father.Name);
						}
					}
					ancestral = father.Father;

					while (ancestral != null) {

						if (father.MaxMin.Equals (Nodo.MaxOrMin.Max)) {
							if (ancestral.MaxMin.Equals (Nodo.MaxOrMin.Min) && ancestral.FUtility <= father.FUtility) {
								while (stack [stack.Count - 1] != father) {
									stack.RemoveAt (stack.Count - 1);
									Debug.Log("5Podou o " + stack[stack.Count - 1].Name);
								}
							}
						} else {
							if (ancestral.MaxMin.Equals (Nodo.MaxOrMin.Max) && ancestral.FUtility >= father.FUtility) {
								while (stack [stack.Count - 1] != father) {
									stack.RemoveAt (stack.Count - 1);
									Debug.Log("6Podou o " + stack[stack.Count - 1].Name);
								}
							}
						}
						ancestral = ancestral.Father;

					}

				}

			}

			if (stack.Count > 0) {
				if (float.IsNaN (stack [stack.Count - 1].FUtility)) {
					currentNode = stack [stack.Count - 1];
				} else {
					currentNode = stack [stack.Count - 1];
					stack.RemoveAt (stack.Count - 1);
				}
			} else {
				break;
			}

		} 

		Debug.Log ("Fim MINIMAX");
		return raiz.FUtility;

	}

}
