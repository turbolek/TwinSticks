using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

    private const int bufferFrames = 100;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
    private Rigidbody rigidbody;
    private GameManager gameManager;

	// Use this for initialization
	void Start () {
        gameManager = FindObjectOfType<GameManager>();
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gameManager.recording) Record();
        else Playback();
    }

    void Playback()
    {
        rigidbody.isKinematic = true;
        int frameNumber = Time.frameCount % bufferFrames;
        transform.position = keyFrames[frameNumber].pos;
        transform.rotation = keyFrames[frameNumber].rot;
    }

    private void Record()
    {
        rigidbody.isKinematic = false;
        int frameNumber = Time.frameCount % bufferFrames;
        float time = Time.time;

        keyFrames[frameNumber] = new MyKeyFrame(time, transform.position, transform.rotation);
    }
}

public class MyKeyFrame
{
    public float time;
    public Vector3 pos;
    public Quaternion rot;

    public MyKeyFrame(float t, Vector3 p, Quaternion r)
    {
        time = t;
        pos = p;
        rot = r;
    }
}