using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class HandAnimatorManager : MonoBehaviour
{
	public StateModel[] stateModels;
	Animator handAnimator;

	public int currentState = 100;
	int lastState = -1;

	private long prevMilliTime = 0; // modify suzuki
	private bool sendStateNormal = false; // modify suzuki

	// Use this for initialization
	void Start ()
	{
		handAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.BackQuote)) {
			currentState = 0;
		} else if (Input.GetKeyDown (KeyCode.Alpha1)) {
			currentState = 1;
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			currentState = 2;
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			currentState = 3;
		} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			currentState = 4;
		} else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			currentState = 5;
		} else if (Input.GetKeyDown (KeyCode.Alpha6)) {
			currentState = 6;
		} else if (Input.GetKeyDown (KeyCode.Alpha7)) {
			currentState = 7;
		} else if (Input.GetKeyDown (KeyCode.Alpha8)) {
			currentState = 8;
		} else if (Input.GetKeyDown (KeyCode.Alpha9)) {
			currentState = 9;
		} else if (Input.GetKeyDown (KeyCode.Alpha0)) {
			currentState = 10;
		} else if (Input.GetKeyDown (KeyCode.I)) {	
			currentState = 100;
		}

		if (lastState != currentState) {
			lastState = currentState;
			handAnimator.SetInteger ("State", currentState);
			TurnOnState (currentState);
		}

		handAnimator.SetBool ("Action", Input.GetMouseButton (0));
		handAnimator.SetBool ("Hold", Input.GetMouseButton (1));

		// modify suzuki
		// コントローラーの検知
		var controller = OVRInput.GetActiveController();
		if(controller == OVRInput.Controller.LTrackedRemote || controller == OVRInput.Controller.RTrackedRemote)
		{
			/*
			if (OVRInput.GetDown(OVRInput.Button.Back))
			{
				SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
			}
			else if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
			{
				Debug.Log ("Get PrimaryHandTrigger");
				handAnimator.SetBool ("Hold", true);
			}
			else if (OVRInput.GetDown(OVRInput.Button.DpadDown))
			{
				Debug.Log ("DpadDown");
				handAnimator.SetBool ("Hold", true);
			}
			else if (OVRInput.GetDown(OVRInput.Button.Any))
			{
				Debug.Log ("Any");
				handAnimator.SetBool ("Hold", true);
			}
			*/

			// virtual
			/*
			if ( OVRInput.Get(OVRInput.Button.One) ) SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

			if ( OVRInput.GetDown(OVRInput.Button.One) ) SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

			if ( OVRInput.GetUp(OVRInput.Button.One) ) SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

			if ( OVRInput.Get(OVRInput.Button.Two) ) SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

			if ( OVRInput.GetDown(OVRInput.Button.Two) ) SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

			if ( OVRInput.GetUp(OVRInput.Button.Two) ) SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
*/

			if (OVRInput.Get (OVRInput.Button.PrimaryIndexTrigger)) {
				//SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
				handAnimator.Play ("Hold");

				//
				long currentMilliTime = DateTime.Now.Hour * 60 * 60 * 1000 + DateTime.Now.Minute * 60 * 1000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
				if (currentMilliTime - prevMilliTime > 1 * 1000) {
					StartCoroutine (GetHttpText ("mode=set&id=avatar001&anime=hold"));
					prevMilliTime = currentMilliTime;
					sendStateNormal = false;
				}
			} 
			else {
				handAnimator.Play ("Normal");

				// リクエスト数を減らすため、変化後の初回だけ送る
				if (!sendStateNormal) {
					StartCoroutine (GetHttpText ("mode=set&id=avatar001&anime=normal"));
					sendStateNormal = true;
				}
			}

			//if ( OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) ) SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

			//if ( OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) ) SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

			/*
			if ( OVRInput.Get(OVRInput.Button.Up) ) SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

			if ( OVRInput.Get(OVRInput.Button.Down) ) SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

			if ( OVRInput.Get(OVRInput.Button.Left) ) SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

			if ( OVRInput.Get(OVRInput.Button.Right) ) SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
*/
			/*

			if ( OVRInput.Get(OVRInput.Touch.PrimaryTouchpad) ) SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

			if ( OVRInput.GetDown(OVRInput.Touch.PrimaryTouchpad) ) SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

			if ( OVRInput.GetUp(OVRInput.Touch.PrimaryTouchpad) ) SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

			if ( OVRInput.Get(OVRInput.Button.PrimaryTouchpad) ) SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

			if ( OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad) ) SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

			if ( OVRInput.GetUp(OVRInput.Button.PrimaryTouchpad) ) SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
			*/

			// raw
			/*
			if ( OVRInput.Get(OVRInput.RawButton.Start) ) SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
			if ( OVRInput.GetDown(OVRInput.RawButton.Start) ) SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
			if ( OVRInput.GetUp(OVRInput.RawButton.Start) ) SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
			if ( OVRInput.Get(OVRInput.RawButton.Back) ) SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
			if ( OVRInput.GetDown(OVRInput.RawButton.Back) ) SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
			if ( OVRInput.GetUp(OVRInput.RawButton.Back) ) SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
			if ( OVRInput.Get(OVRInput.RawButton.A) ) SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
			if ( OVRInput.GetDown(OVRInput.RawButton.A) ) SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
			if ( OVRInput.GetUp(OVRInput.RawButton.A) ) SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
			*/
		}
	}

	void TurnOnState (int stateNumber)
	{
		foreach (var item in stateModels) {
			if (item.stateNumber == stateNumber && !item.go.activeSelf)
				item.go.SetActive (true);
			else if (item.go.activeSelf)
				item.go.SetActive (false);
		}
	}

	IEnumerator GetHttpText(string query) {
		UnityWebRequest request = UnityWebRequest.Get("http://ik1-325-22908.vs.sakura.ne.jp/?" + query);
		yield return request.Send();

		if (request.isError) {
			Debug.Log(request.error);
		} else {
			if (request.responseCode == 200) {
				string text = request.downloadHandler.text;
				byte[] results = request.downloadHandler.data;
			}
		}
	}

}

[Serializable]
public class StateModel
{
	public int stateNumber;
	public GameObject go;
}
