using UnityEngine;
using System.Collections;
using Valve.VR;

public class ViveInputController : MonoBehaviour {

    SteamVR_TrackedObject trackedObject;
    public GameController gameController;
    public int controllerIndex;

    protected int handIndex = 0;

    void Awake ()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();


    }
	void Update ()
    {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObject.index);
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            gameController.ResetGame();
        }

        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            var count = gameObject.transform.childCount;
            gameObject.transform.GetChild(handIndex).gameObject.SetActive(false);
            Debug.Log(count);
            handIndex = handIndex >= count - 1 ? 0 : handIndex +=1;
            Debug.Log(handIndex);
            gameObject.transform.GetChild(handIndex).gameObject.SetActive(true);
        }

        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
		{
            Debug.Log("change gravity");
			var gravity = Physics.gravity;
            if (controllerIndex == 1)
            {
                gravity.y -= 0.5f;
            }
            else
            {
                gravity.y += 0.5f;
            }
			Physics.gravity = gravity;
			gameController.SetMessage("Gravity Set: " + gravity.y);
		}
	}

    void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(Vibrate());
    }
    protected IEnumerator Vibrate()
    {
        for (int i = 0; i < 10; i++)
        {
            SteamVR_Controller.Input((int)trackedObject.index).TriggerHapticPulse(3999);
            yield return new WaitForSeconds(0.000001f);
        }
    }

}
