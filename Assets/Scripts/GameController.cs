using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
	public Text ScoreDisplay;
	public GameObject Table;
	public GameObject TableObjectsParent;
    public GameObject ObstaclesParent;

    protected Vector3 TableStartPosition = new Vector3(-0.5f, 0, 0);
	protected TableObjectGenerator TableObjectGeneratorScript;
	protected int HighScore = 0;
	protected bool NewHighScore = false;

	void Start ()
	{
		TableObjectGeneratorScript = GetComponent<TableObjectGenerator>();
		HighScore = PlayerPrefs.GetInt("HighScore", 0);
	}
	
	void Update ()
	{
		var dispText = "Score: " + String.Format("{0:n0}", GameInformation.Score) + "\nHigh Score: " + HighScore;		
		if (!NewHighScore && GameInformation.Score > HighScore)
		{
			NewHighScore = true;
		}
		if (NewHighScore)
		{
			dispText += "\nNEW HIGH SCORE!!!!";
		}
		ScoreDisplay.text = dispText;

		if (Input.GetKeyDown(KeyCode.R))
			ResetGame();
	}

	public void ResetGame()
	{
		var children = new List<GameObject>();
		foreach (Transform child in TableObjectsParent.transform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));

        var obstacles = new List<GameObject>();
        foreach (Transform obstacle in ObstaclesParent.transform) obstacles.Add(obstacle.gameObject);
        obstacles.ForEach(obstacle => Destroy(obstacle));

        Table.transform.position = TableStartPosition;
		Table.transform.rotation = new Quaternion(0, 0, 0, 0);

		HighScore = PlayerPrefs.GetInt("HighScore");
		if (GameInformation.Score > HighScore)
		{
			HighScore = GameInformation.Score;
			PlayerPrefs.SetInt("HighScore", HighScore);
		}
		NewHighScore = false;

		GameInformation.Score = 0;

		TableObjectGeneratorScript.GenerateObjects();
	}
}
