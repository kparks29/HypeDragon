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
    public GameObject Confetti1;
    public GameObject Confetti2;

    protected Vector3 TableStartPosition = new Vector3(-0.3f, 0, 0);
	protected TableObjectGenerator TableObjectGeneratorScript;
	protected int HighScore = 0;
	protected bool NewHighScore = false;

	[HideInInspector]
	public float MessageCountdown = 0;
	[HideInInspector]
	public string Message = "";

	void Start ()
	{
		TableObjectGeneratorScript = GetComponent<TableObjectGenerator>();
        PlayerPrefs.DeleteAll();    
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
	}
	
	void Update ()
	{
		//Display High Score Stuff
		var dispText = "Score: " + String.Format("{0:n0}", GameInformation.Score) + "\nHigh Score: " + String.Format("{0:n0}", HighScore);		
		if (!NewHighScore && GameInformation.Score > HighScore)
		{
			NewHighScore = true;
            Confetti1.SetActive(true);
            Confetti2.SetActive(true);
            StartCoroutine(DestroyConfetti());
		}
		if (NewHighScore)
		{
			dispText += "\nNEW HIGH SCORE!!!!";
		}

		//Display Messages
		if (Message != "")
		{
            if (MessageCountdown > 0)
            {
                MessageCountdown -= Time.deltaTime;
                dispText += "\n" + Message;
            }
            else
            {
                Message = "";
            }
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

        Table.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
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
        Physics.gravity = new Vector3(0, -9.81f, 0);
        Confetti1.SetActive(false);
        Confetti2.SetActive(false);
    }

	public void SetMessage(string message)
	{
		Message = message;
		MessageCountdown = 1f;
	}

    public IEnumerator DestroyConfetti ()
    {
        yield return new WaitForSeconds(2.5f);
        Confetti1.SetActive(false);
        Confetti2.SetActive(false);
    }
}
