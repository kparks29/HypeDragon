using UnityEngine;
using System.Collections;
using Valve.VR;

public class ViveInputController : MonoBehaviour {
	
	void Update ()
    {
        if (SteamVR_Controller.Input(0).GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("TriggerClicked");
        }
    }

}
