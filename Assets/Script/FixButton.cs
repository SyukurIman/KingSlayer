using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixButton : MonoBehaviour {
	public SpriteRenderer targetsize;

	void Start () {
		float screenRatio = (float)Screen.width / (float)Screen.height;
		float targetRatio = targetsize.bounds.size.x / targetsize.bounds.size.y;

		if (screenRatio >= targetRatio) {
			Camera.main.orthographicSize = targetsize.bounds.size.y / 2;
		} else {
			float differenceInsize = targetRatio / screenRatio;
			Camera.main.orthographicSize = targetsize.bounds.size.y / 2 * differenceInsize;
		}
	}
}
