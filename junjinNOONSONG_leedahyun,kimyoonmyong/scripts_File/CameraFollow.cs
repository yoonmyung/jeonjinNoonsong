using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

//기존에 사용했었던 길건너친구들 방식 카메라 무브 함수
public class CameraFollow : MonoBehaviour {

	public GameObject chickenPlayer;
	Vector3 shouldPos;

	// Update is called once per frame
	void Update () {
		shouldPos = Vector3.Lerp (gameObject.transform.position, chickenPlayer.transform.position, Time.deltaTime);
		gameObject.transform.position = new Vector3 (shouldPos.x, 1, shouldPos.z+0.2f);
	}
}
