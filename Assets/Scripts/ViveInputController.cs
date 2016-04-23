using UnityEngine;
using System.Collections;
using Valve.VR;

public class ViveInputController : MonoBehaviour {

    SteamVR_TrackedObject trackedObject;
    public GameController gameController;

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
    }

}
