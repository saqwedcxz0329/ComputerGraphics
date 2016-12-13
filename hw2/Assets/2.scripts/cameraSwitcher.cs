using UnityEngine;
using System.Collections;

public class cameraSwitcher : MonoBehaviour {

	public Camera rearCam;
	public Camera driverCam;

	// Use this for initialization
	void Start () {
		rearCam.enabled = true;
		driverCam.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.C)) {
			rearCam.enabled = !rearCam.enabled;
			driverCam.enabled = !driverCam.enabled;
		}

	}
}
