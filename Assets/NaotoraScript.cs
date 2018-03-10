using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaotoraScript : MonoBehaviour {

	private Animator animator;
	private long cnt = 0;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		
		// (3)
		long animFrameAll = 90; //100 * 2;
		long animFrameCnt = cnt % animFrameAll;

		if (animFrameCnt > (animFrameAll - 1) - 10) {
			transform.position += transform.up * -0.02f;
		} else if (animFrameCnt > (animFrameAll - 1) - 20) {
			transform.position += transform.up * 0.02f;
		} else {
		}
		transform.Rotate (0, 1, 0);
		transform.position += transform.forward * 0.01f;
		animator.SetBool ("run", true);	



		// (1)
		// Position x=1,y=0,z=2
		// 回転させて
		/*
		transform.Rotate (0, 1, 0);

		// 前後移動
		transform.position += transform.forward * 0.01f;

		// アニメ
		animator.SetBool ("run", true);
		*/


		// (2)
		/* 
		// Position x=5,y=0,z=0
		if (cnt % 3 == 0) {
			// 回転させて
			transform.Rotate (0, 1, 0);

			// 前後移動
			transform.position += transform.forward * 0.01f * 8;

			// アニメ
			animator.SetBool ("run", true);
		}
		*/

		cnt++;
		if (cnt == long.MaxValue)
			cnt = 0;
	}
}
