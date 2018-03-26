using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SelfieStick : MonoBehaviour {

    GameObject player;

    public float panSpeed = 10f;
    Vector3 armRotation;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        armRotation = transform.rotation.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
        armRotation.y += CrossPlatformInputManager.GetAxis("Right Stick H") * panSpeed;
        armRotation.x += CrossPlatformInputManager.GetAxis("Right Stick V") * panSpeed;
        transform.position = player.transform.position;

        transform.rotation = Quaternion.Euler(armRotation);
	}
}
