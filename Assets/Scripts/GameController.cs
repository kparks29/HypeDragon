using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
	public Text ScoreDisplay;
	public GameObject Table;
	public GameObject TableObjectsParent;

	protected Vector3 TableStartPosition = new Vector3(-0.5f, 0, 0);
	protected TableObjectGenerator TableObjectGeneratorScript;

	void Start ()
	{
		TableObjectGeneratorScript = GetComponent<TableObjectGenerator>();
	}
	
	void Update ()
	{
		//ScoreDisplay.text = "Score: " + GameInformation.Score;
		if (Input.GetKeyDown(KeyCode.R))
			ResetGame();
	}

	public void ResetGame()
	{
		var children = new List<GameObject>();
		foreach (Transform child in TableObjectsParent.transform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));

		Table.transform.position = TableStartPosition;
		Table.transform.rotation = new Quaternion(0, 0, 0, 0);

		GameInformation.Score = 0;

		TableObjectGeneratorScript.GenerateObjects();
	}
}
