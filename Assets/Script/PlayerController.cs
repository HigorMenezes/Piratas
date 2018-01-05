using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private bool flag = true;

	public GameObject move;
	public GameObject attack;

	private RaycastHit hit;

	private List<GameObject> moveObjects = new List<GameObject>();
	private List<Movement> movements = new List<Movement>();

	void Start () {
	}

	void Update () {
		if (GameController.turn.ToString().Equals (this.tag)) {
			if (Input.GetKeyDown (KeyCode.Mouse0) && flag) {
				flag = false;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (ray, out hit)) {
					if (hit.collider.tag.Equals (this.tag)) {
						destroy ();
						movementCalculate (hit.transform.localPosition);
					}else if (hit.collider.tag.Equals ("Move")){
						GameController.turn = GameController.Turn.Movement;
						int index = moveObjects.IndexOf (hit.transform.gameObject);
						destroy ();
						MakeMovement.move(movements[index], this.tag);

					}
				}
			}
		}
		if (Input.GetKeyUp (KeyCode.Mouse0)) {
			flag = true;
		}
	}

	private void movementCalculate(Vector3 pos){

		movements = MovementCalculate.calculate(GameController.board.clone() , new Vector2(pos.x, pos.y), this.tag);
		GameObject aux;

		foreach(Movement movement in movements){
			if (movement.MoveType.Equals (Movement.Move.Move)) {
				aux = Instantiate (move, this.transform);
				Vector3 to = new Vector3 (movement.To.x, movement.To.y, -aux.transform.position.y);
				aux.transform.localPosition = to;
				moveObjects.Add (aux);
			} else {
				aux = Instantiate (attack, this.transform);
				Vector3 to = new Vector3 (movement.To.x, movement.To.y, -aux.transform.position.y);
				aux.transform.localPosition = to;
				moveObjects.Add(aux);
			}
		}

	}

	private void destroy(){
		foreach (GameObject gameObject in moveObjects) {
			Destroy (gameObject);
		}
		moveObjects.Clear ();
	}

}
