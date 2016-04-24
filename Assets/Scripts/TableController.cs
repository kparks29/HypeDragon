using UnityEngine;
using System.Collections;

public class TableController : MonoBehaviour
{
	public BoomBoxController BoomBoxCtrl;

	protected bool PlayingVictory = false;
	protected float ChangeTimer = 0;
	protected float ChangeTimerMax = 0.5f;

	// Use this for initialization
	void Start ()
	{
	
	}

	// Update is called once per frame
	void Update()
	{
		if (!PlayingVictory)
		{
			if ((Mathf.Abs(transform.eulerAngles.x) > 30 && Mathf.Abs(transform.eulerAngles.x) < 330)
				|| (Mathf.Abs(transform.eulerAngles.z) > 30 && Mathf.Abs(transform.eulerAngles.z) < 330))
			{
				BoomBoxCtrl.ChangeToCrazyMusic();
				PlayingVictory = true;
			}
		}
		else
		{
			if ((Mathf.Abs(transform.eulerAngles.x) < 1 || Mathf.Abs(transform.eulerAngles.x) > 359)
				&& (Mathf.Abs(transform.eulerAngles.z) < 1 || Mathf.Abs(transform.eulerAngles.z) > 350))
			{
				if (ChangeTimer < ChangeTimerMax)
				{
					ChangeTimer += Time.deltaTime;
				}
				else
				{
					BoomBoxCtrl.ChangeToNormalMusic();
					PlayingVictory = false;
					ChangeTimer = 0;
				}
			}
			else if (ChangeTimer > 0)
			{
				ChangeTimer = 0;
			}
		}
	}
}
