using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
	public Text ScoreDisplay;

	void Start ()
	{
		
	}
	
	void Update ()
	{
		ScoreDisplay.text = "Score: " + GameInformation.Score;
	}
}
