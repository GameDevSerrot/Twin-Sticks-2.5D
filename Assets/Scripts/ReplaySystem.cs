﻿using UnityEngine;
using System.Collections;

public class ReplaySystem: MonoBehaviour	{

    private const int bufferFrames = 100;   //the number of frames we're storing
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];

    private Rigidbody rigidBody;

	//Use this for initialization
	void Start(){

        rigidBody = GetComponent<Rigidbody>();
	
	}

    //Update is called once per frame
    void Update()
    {
        Record();
    }

    private void Record()
    {
        rigidBody.isKinematic = true;
        int frame = Time.frameCount % bufferFrames;
        float time = Time.time;
        print("Writing frame " + frame);
        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }

    void PlayBack()
    {
        rigidBody.isKinematic = true;
        int frame = Time.frameCount % bufferFrames;
        print("Reading frame " + frame);
        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;
    }
}

/// <summary>
/// A structure for storing time, position, and rotation
/// </summary>
public struct MyKeyFrame
{
	public float frameTime;
	public Vector3 position;
	public Quaternion rotation;

	//constructor for MyKeyFrame
	public MyKeyFrame (float aTime, Vector3 aPosition, Quaternion aRotation)
    {
		frameTime = aTime;
		position = aPosition;
		rotation = aRotation;
	}
}