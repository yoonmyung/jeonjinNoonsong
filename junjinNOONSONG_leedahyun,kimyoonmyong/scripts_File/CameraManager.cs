using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {
	public Camera firstPersonCamera;
	public Camera overheadCamera;
	public Camera fullscreenCamera;
	int check = 1;

	void Start() {
		ShowFirstPersonView ();
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Q)) {
			if (check == 1) {
				ShowOverheadView ();
				check = 2;
			} else if (check == 2) {
				ShowFullScreenView ();
				check = 3;
			} else {
				ShowFirstPersonView ();
				check = 1;
			}
		}
	}

	public void ShowOverheadView() {
		firstPersonCamera.enabled = false;
		fullscreenCamera.enabled = false;
		overheadCamera.enabled = true;
	}

	public void ShowFirstPersonView() {
		firstPersonCamera.enabled = true;
		fullscreenCamera.enabled = false;
		overheadCamera.enabled = false;
	}

	public void ShowFullScreenView() {
		firstPersonCamera.enabled = false;
		fullscreenCamera.enabled = true;
		overheadCamera.enabled = false;
	}
}
