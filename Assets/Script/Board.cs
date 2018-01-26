using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Board{

	private Vector2[] blueTeam = new Vector2[3];
	private Vector2[] redTeam = new Vector2[3];

	public Board ()
	{
		defaultBoard ();
	}
	

	public Board (Vector2[] blueTeam, Vector2[] redTeam)
	{
		this.blueTeam = blueTeam;
		this.redTeam = redTeam;
	}
	

	private void defaultBoard(){
		blueTeam [0] = new Vector2 (5, 1);
		blueTeam [1] = new Vector2 (5, 3);
		blueTeam [2] = new Vector2 (6, 2);

		redTeam [0] = new Vector2 (1, 1);
		redTeam [1] = new Vector2 (1, 3);
		redTeam [2] = new Vector2 (0, 2);
	}

	public Board clone(){
		Vector2[] array1 = new Vector2[3];
		Vector2[] array2 = new Vector2[3];

		array1 [0] = blueTeam [0];
		array1 [1] = blueTeam [1];
		array1 [2] = blueTeam [2];

		array2 [0] = redTeam [0];
		array2 [1] = redTeam [1];
		array2 [2] = redTeam [2];

		return new Board (array1, array2);
	}


	public Vector2[] BlueTeam {
		get {
			return this.blueTeam;
		}
		set {
			blueTeam = value;
		}
	}

	public Vector2[] RedTeam {
		get {
			return this.redTeam;
		}
		set {
			redTeam = value;
		}
	}

	public override string ToString ()
	{
		return string.Format ("[Board: blueTeam={0}, redTeam={1}, BlueTeam={2}, RedTeam={3}]", blueTeam[0],  BlueTeam[1],redTeam[0], RedTeam[1]);
	}
	

	public float fUtility(string tag){

		int quantidadeBlue = 0;
		int quantidadeRed = 0;

		float distBlueRed = 0.0001f;
		float distRedBlue = 0.0001f;

		quantidadeBlue += blueTeam [0].x != -10 ? 1 : 0;
		quantidadeBlue += blueTeam [1].x != -10 ? 1 : 0;

		quantidadeRed += redTeam [0].x != -10 ? 1 : 0;
		quantidadeRed += redTeam [1].x != -10 ? 1 : 0;


		if (blueTeam [0].x != -10.0f && blueTeam [1].x != -10.0f) {
			distBlueRed += (Mathf.Abs (blueTeam [0].x - redTeam [2].x) +
			Mathf.Abs (blueTeam [0].y - redTeam [2].y) +
			Mathf.Abs (blueTeam [1].x - redTeam [2].x) +
			Mathf.Abs (blueTeam [1].y - redTeam [2].y)) / 2;
		} else if (blueTeam [0].x != -10f) {
			distBlueRed += Mathf.Abs (blueTeam [0].x - redTeam [2].x) +
			Mathf.Abs (blueTeam [0].y - redTeam [2].y);
		} else if (blueTeam [1].x != -10f) {
			distBlueRed += Mathf.Abs (blueTeam [1].x - redTeam [2].x) +
			Mathf.Abs (blueTeam [1].y - redTeam [2].y);
		} else {
			distBlueRed = 20;
		}

		if (redTeam [0].x != -10.0f && redTeam [1].x != -10.0f) {
			distRedBlue += (Mathf.Abs (redTeam [0].x - blueTeam [2].x) +
				Mathf.Abs (redTeam [0].y - blueTeam [2].y) +
				Mathf.Abs (redTeam [1].x - blueTeam [2].x) +
				Mathf.Abs (redTeam [1].y - blueTeam [2].y)) / 2;
		} else if (redTeam [0].x != -10f) {
			distRedBlue += Mathf.Abs (redTeam [0].x - blueTeam [2].x) +
				Mathf.Abs (redTeam [0].y - blueTeam [2].y);
		} else if (redTeam [1].x != -10f) {
			distRedBlue += Mathf.Abs (redTeam [1].x - blueTeam [2].x) +
				Mathf.Abs (redTeam [1].y - blueTeam [2].y);
		} else {
			distRedBlue = 20;
		}

		/*if (blueTeam [0].x != -10f) {
			distBlueRed += Mathf.Abs (blueTeam [0].x - redTeam [2].x) +
						   Mathf.Abs (blueTeam [0].y - redTeam [2].y);
		} else {
			distBlueRed -= 175.0f;
		}
		if (blueTeam [1].x != -10f) {
			distBlueRed += Mathf.Abs (blueTeam[1].x - redTeam[2].x) +
						   Mathf.Abs (blueTeam[1].y - redTeam[2].y);
		} else {
			distBlueRed -= 175.0f;
		}

		if (redTeam [0].x != -10f) {
			distRedBlue += Mathf.Abs (redTeam [0].x - blueTeam [2].x) +
						   Mathf.Abs (redTeam [0].y - blueTeam [2].y);
		} else {
			distRedBlue -= 175.0f;
		}
		if (redTeam [1].x != -10f) {
			distRedBlue += Mathf.Abs (redTeam[1].x - blueTeam[2].x) +
						   Mathf.Abs (redTeam[1].y - blueTeam[2].y);
		} else {
			distRedBlue -= 175.0f;
		}*/

		if (tag.Equals ("BlueTeam")) {
			return (quantidadeBlue - 2)*450 + (2 - quantidadeRed)*400 + 150 * 1/distBlueRed - 150 * 1/distRedBlue;
		} else {
			return (quantidadeRed - 2)*450 + (2 - quantidadeBlue)*400 + 150 * 1/distRedBlue - 150 * 1/distBlueRed;
		}

	}

}
