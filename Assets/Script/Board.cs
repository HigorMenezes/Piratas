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

		float distBlueRed = 0;
		float distRedBlue = 0;

		quantidadeBlue += blueTeam [0].x != -10 ? 1 : 0;
		quantidadeBlue += blueTeam [1].x != -10 ? 1 : 0;

		quantidadeRed += redTeam [0].x != -10 ? 1 : 0;
		quantidadeRed += redTeam [1].x != -10 ? 1 : 0;

		if (blueTeam[0].x != -10f){
			distBlueRed += Mathf.Abs (blueTeam [0].x - redTeam [2].x) +
						   Mathf.Abs (blueTeam [0].y - redTeam [2].y);
		}
		if (blueTeam [1].x != -10f) {
			distBlueRed += Mathf.Abs (blueTeam[1].x - redTeam[2].x) +
						   Mathf.Abs (blueTeam[1].y - redTeam[2].y);
		}

		if (redTeam[0].x != -10f){
			distRedBlue += Mathf.Abs (redTeam [0].x - blueTeam [2].x) +
						  Mathf.Abs (redTeam [0].y - blueTeam [2].y);
		}
		if (redTeam [1].x != -10f) {
			distRedBlue += Mathf.Abs (redTeam[1].x - blueTeam[2].x) +
						   Mathf.Abs (redTeam[1].y - blueTeam[2].y);
		}

		if (tag.Equals ("BlueTeam")) {
			return 500 * (quantidadeBlue - quantidadeRed) - 25 * distBlueRed;
		} else {
			return 500 * (quantidadeRed - quantidadeBlue) - 25 * distRedBlue;
		}

	}

}
