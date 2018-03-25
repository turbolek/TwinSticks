using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool recording = true;
	
	// Update is called once per frame
	void Update () {
        recording = !CrossPlatformInputManager.GetButton("Fire1");
	}
}
