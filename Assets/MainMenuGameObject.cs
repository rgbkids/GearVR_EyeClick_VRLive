using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainMenuGameObject : MonoBehaviour {
	public static long StartMilliTime
	{
		get { return startMilliTime; }
	}

	public static long startMilliTime; // modify suzuki

	// Use this for initialization
	void Start () {
		startMilliTime = DateTime.Now.Hour * 60 * 60 * 1000 + DateTime.Now.Minute * 60 * 1000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
