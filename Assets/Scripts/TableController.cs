using UnityEngine;
using System.Collections;

public class TableController : MonoBehaviour
{
	public BoomBoxController BoomBoxCtrl;

	protected bool PlayingVictory = false;
	protected float ChangeTimer = 0;
	protected float ChangeTimerMax = 0.5f;
    protected Rigidbody TableRigidBody;

	// Use this for initialization
	void Start ()
	{
        TableRigidBody = GetComponent<Rigidbody>();
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

    //void OnTriggerEnter(Collider collider)
    //{
    //    if (collider.gameObject.name.Contains("Controller"))
    //    {
    //        //TableRigidBody.velocity = collider.gameObject.GetComponent<Rigidbody>().velocity * 10;
    //        Debug.Log(collider.gameObject.name + ", " + collider.gameObject.GetComponent<Rigidbody>().velocity);
    //        var direction = collider.gameObject.transform.position - transform.position;
    //        TableRigidBody.AddForceAtPosition(direction.normalized * 5, transform.position);
    //        //ApplyForce(Rigidbody body) {
    //    }
    //}
}
