using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMovement : MonoBehaviour {

	private static Animator animator;

	private bool walk;

	private static float time;
	private float maxTime;

	private static GameObject moveFrom;
	private static GameObject moveTo;

	private static Vector3 from;
	private static Vector3 to;

	private static Movement movement;

	private static RaycastHit hit;

	private static bool flag;

	void Start () {
		maxTime = 2f;
		walk = false;
		time = 0f;
		moveFrom = null;
		moveTo = null;
	}

	void FixedUpdate () {
		if (GameController.turn.Equals (GameController.Turn.Movement) && flag) {
			time += Time.fixedDeltaTime;
			if (time >= 0) {

				if (!walk) {
					animator.Play ("Walk");
					walk = true;
				}

				if (moveTo != null) {
					Destroy (moveTo);
					moveTo = null;
				}

				/*moveFrom.transform.localPosition = Vector3.LerpUnclamped (
					moveFrom.transform.localPosition,
					new Vector3 (movement.To.x, movement.To.y, moveFrom.transform.localPosition.z),
					0.04f);*/

				moveFrom.transform.localPosition += ((new Vector3 (movement.To.x, movement.To.y, moveFrom.transform.localPosition.z) -
					new Vector3 (movement.From.x, movement.From.y, moveFrom.transform.localPosition.z))/maxTime) * Time.fixedDeltaTime;


				if (time > maxTime) {
					moveFrom.transform.localPosition = new Vector3 (movement.To.x, movement.To.y, moveFrom.transform.localPosition.z);
					if (moveFrom.tag.Equals ("BlueTeam")) {
						moveFrom.transform.forward = new Vector3 (-1f, 0f, 0f);
					} else {
						moveFrom.transform.forward = new Vector3 (1f, 0f, 0f);
					}
					walk = false;
					animator.Play ("Idle");
					flag = false;
					GameController.changeTurn ();
				}
			}
		}
	}

	public static void move (Movement m, string tag){
		movement = m;
		attBoard (tag);

		from = new Vector3 (movement.From.x - 1.5f, -5f, movement.From.y - 2f);
		to = new Vector3 (movement.To.x - 1.5f, -5f, movement.To.y - 2f);

		if (Physics.Raycast (from, Vector3.up, out hit)) {
			moveFrom = hit.collider.transform.gameObject;
			moveFrom.transform.forward = ((Vector3)to - from).normalized;
		}

		if (Physics.Raycast (to, Vector3.up, out hit)) {
			moveTo = hit.collider.transform.gameObject;
		}

		animator = moveFrom.GetComponent<Animator> ();
		if (moveTo != null && !moveTo.tag.Equals("Move")) {
			if (Random.Range (0, 2) == 0) {
				animator.Play ("SwordAttack");
			} else {
				animator.Play ("GunAttack");
			}
			time = -1f;
		} else {
			time = 0f;
		}
		flag = true;

	}

	private static void attBoard(string tag){
		if (tag.Equals ("BlueTeam")) {
			if (GameController.board.BlueTeam [0].Equals (movement.From)) {
				GameController.board.BlueTeam [0] = movement.To;
			} else if (GameController.board.BlueTeam [1].Equals (movement.From)){
				GameController.board.BlueTeam [1] = movement.To;
			}

			if (GameController.board.RedTeam [0].Equals (movement.To)) {
				GameController.board.RedTeam [0] = new Vector2(-10f, -10f);
			} else if (GameController.board.RedTeam [1].Equals (movement.To)){
				GameController.board.RedTeam [1] = new Vector2(-10f, -10f);
			}
		} else {
			if (GameController.board.RedTeam [0].Equals (movement.From)) {
				GameController.board.RedTeam [0] = movement.To;
			} else if (GameController.board.RedTeam [1].Equals (movement.From)){
				GameController.board.RedTeam [1] = movement.To;
			}

			if (GameController.board.BlueTeam [0].Equals (movement.To)) {
				GameController.board.BlueTeam [0] = new Vector2(-10f, -10f);
			} else if (GameController.board.BlueTeam [1].Equals (movement.To)){
				GameController.board.BlueTeam [1] = new Vector2(-10f, -10f);
			}
		}
	}

}
