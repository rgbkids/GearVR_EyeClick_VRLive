using UnityEngine;
using System.Collections;

public class PassThroughCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		WebCamTexture webcamTexture = new WebCamTexture(1280,720,25);
		gameObject.GetComponent<Renderer>().material.mainTexture = webcamTexture;
		webcamTexture.Play();
	}

	// Update is called once per frame
	void Update () {

	}
}