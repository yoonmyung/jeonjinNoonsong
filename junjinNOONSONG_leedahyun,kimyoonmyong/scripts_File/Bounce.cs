using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour {

	float lerpTime;
	float currentLerpTime;
	float perc = 1;

	Vector3 startPos;
	Vector3 endPos;

	bool firstInput;
	public bool justJump;

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("up") || Input.GetButtonDown ("down") || Input.GetButtonDown ("left") || Input.GetButtonDown ("right")) {
			if (perc == 1) {
				lerpTime = 1;
				currentLerpTime = 0;
				firstInput = true;
				justJump = true;
			}
		}

		startPos = gameObject.transform.position;

		if (Input.GetButtonDown ("right") && gameObject.transform.position == endPos) {
			endPos = new Vector3 (transform.position.x + 2, transform.position.y, transform.position.z);
		}

		if (Input.GetButtonDown ("left") && gameObject.transform.position == endPos) {
			endPos = new Vector3 (transform.position.x - 2, transform.position.y, transform.position.z);
		}

		if (Input.GetButtonDown ("up") && gameObject.transform.position == endPos) {
			endPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 2);
		}

		if (Input.GetButtonDown ("down") && gameObject.transform.position == endPos) {
			endPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z - 2);
		}

		if (firstInput == true) {
			currentLerpTime += Time.deltaTime * 5;
			perc = currentLerpTime / lerpTime;
			gameObject.transform.position = Vector3.Lerp (startPos, endPos, perc);

			if (perc > 0.8) {
				perc = 1;
			}

			if (Mathf.Round (perc) == 1) {
				justJump = false;
			}
		}
	}
}
