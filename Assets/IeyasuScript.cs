using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IeyasuScript : MonoBehaviour {

	private Animator animator;
	private long cnt = 0;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

		// (3)
		long animFrameAll = 100 * 15;
		long animFrameCnt = cnt % animFrameAll;

		if (animFrameCnt == 0) {
			transform.Rotate (0, 20, 0);
		} else if (animFrameCnt == 1) {
			transform.Rotate (0, 20, 0);
		} else if (animFrameCnt == 2) {
			transform.Rotate (0, 20, 0);
		} else if (animFrameCnt == 3) {
			transform.Rotate (0, 20, 0);
		} else if (animFrameCnt == 4) {
			transform.Rotate (0, 20, 0);
		} else if (animFrameCnt == 5) {
			transform.Rotate (0, 20, 0);
		} else if (animFrameCnt == 6) {
			transform.Rotate (0, 20, 0);
		} else if (animFrameCnt == 7) {
			transform.Rotate (0, 20, 0);
		} else if (animFrameCnt == 8) {
			transform.Rotate (0, 20, 0);
		} else if (animFrameCnt < 700) {
		} else if (animFrameCnt < 1400) {
			//transform.position += transform.forward * 0.005f/5;
		} else if (animFrameCnt < 1400) {
			//transform.position += transform.forward * 0.02f;
		} else if (animFrameCnt == animFrameAll - 1) {
		} else {
		}

		// (1)
		// Position x=-2,y=0,z=2

		// (2)
		/* 
		// Position x=5,y=0,z=0 Rotation y=180
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
