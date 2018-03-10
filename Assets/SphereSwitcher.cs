using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSwitcher : MonoBehaviour {

	private GameObject sphereMain;
	private GameObject sphereSub;

	// Use this for initialization
	void Start () {

		//自分自身が向いている方向の単位ベクトルを取得
		//float angleDir = this.transform.eulerAngles.y * (Mathf.PI / 180.0f);
		//Vector3 dir = new Vector3 (Mathf.Cos (angleDir)*0.1f, 0f, Mathf.Sin (angleDir)*0.1f);


		sphereMain = GameObject.Find ("Sphere100");
		sphereSub  = GameObject.Find ("Sphere100_sub");

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(name + " SphereSwitcher x " + transform.rotation.x + " y " + transform.rotation.y + " z " + transform.rotation.z);

		if (-0.2f < transform.rotation.x && transform.rotation.x < -0.1f) {
			Debug.Log (name + " ___HIT___ x " + transform.rotation.x + " y " + transform.rotation.y + " z " + transform.rotation.z);

			sphereMain.transform.localScale = new Vector3 (110, 110, -110);
			sphereSub.transform.localScale  = new Vector3 (1, 1, -1);
		} else {
			sphereMain.transform.localScale = new Vector3 (1, 1, -1);
			sphereSub.transform.localScale  = new Vector3 (110, 110, -110);
		}
	}
}
