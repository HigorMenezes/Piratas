using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Nodo {

	public enum MaxOrMin{
		Max,
		Min
	}

	private string name;
	private Board board;
	private Nodo father;
	private List<Nodo> children = new List<Nodo>();
	private float fUtility;
	private MaxOrMin maxMin;
	private Movement movement;
	private bool visited;

	public Nodo ()
	{
		this.fUtility = float.NaN;
		father = null;
		children.Clear ();
		visited = false;
	}
	
	public Board Board {
		get {
			return this.board;
		}
		set {
			board = value;
		}
	}

	public Nodo Father {
		get {
			return this.father;
		}
		set {
			father = value;
		}
	}

	public List<Nodo> Children {
		get {
			return this.children;
		}
		set {
			children = value;
		}
	}

	public float FUtility {
		get {
			return this.fUtility;
		}
		set {
			fUtility = value;
		}
	}

	public MaxOrMin MaxMin {
		get {
			return this.maxMin;
		}
		set {
			maxMin = value;
		}
	}

	public Movement Movement {
		get {
			return this.movement;
		}
		set {
			movement = value;
		}
	}

	public string Name {
		get {
			return this.name;
		}
		set {
			name = value;
		}
	}

	public bool Visited {
		get {
			return this.visited;
		}
		set {
			visited = value;
		}
	}

	public void addChildren(Nodo nodo){
		Children.Add (nodo);
	}

}
