using UnityEngine;
using System.Collections;

public class Replay	: MonoBehaviour	{

	//Use this for initialization
	void Star(){
	
	}

	//Update is called once per frame
	void Update()	{
	
	}
}

//helper class for replay class
public struct MyKeyFrame	{
	
	public float frameTime;
	public Vector3 position;
	public float frame;
	Quaternion rotation;

	//constructor for MyKeyFrame
	public MyKeyFrame (float aTime, Vector3 aPosition, Quaternion aRotation)	{
		frameTime = aTime;
		position = aPosition;
		rotation = aRotation;
	}
}