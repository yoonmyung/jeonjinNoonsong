using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class carMovement : MonoBehaviour {
	public Transform prefab;
	float timeSpan;
	float checkTime;
	float moveSpeed;
	Vector3 pos;
	Quaternion rot;
	Scene currentLoadedScene;

	void Start()
	{
		timeSpan = 0.0f;
		checkTime = 4f;
		pos = this.gameObject.transform.position;
		rot = this.gameObject.transform.rotation;
		currentLoadedScene = SceneManager.GetActiveScene ();

		if (currentLoadedScene.name.Equals ("main")) {
			moveSpeed = Random.Range(10, 15);
		}
		else if (currentLoadedScene.name.Equals ("level2")) {
			moveSpeed = Random.Range (15, 20);
		}
		else if (currentLoadedScene.name.Equals ("level3")) {
			moveSpeed = Random.Range(20, 25);
		}

	}

	void Update()
	{	
		if (currentLoadedScene.name.Equals ("main")) {
			if (moveSpeed < 15)
				checkTime = 4f;
			else if (moveSpeed < 20)
				checkTime = 3f;
			else
				checkTime = 2f;

			transform.Translate (Vector3.back *Time.deltaTime* moveSpeed);
			timeSpan += Time.deltaTime;

			if (timeSpan > checkTime) {
				moveSpeed = Random.Range(10, 15);
				Instantiate(prefab, new Vector3(pos.x, pos.y, pos.z), Quaternion.Euler(rot.x, 90f, rot.z));
				transform.Translate (Vector3.back *Time.deltaTime* moveSpeed);
				timeSpan = 0;
			}
		} 

		else if (currentLoadedScene.name.Equals ("level2")) {
			if (moveSpeed < 15)
				checkTime = 4f;
			else if (moveSpeed < 20)
				checkTime = 3f;
			else
				checkTime = 2f;

			transform.Translate (Vector3.back *Time.deltaTime* moveSpeed);
			timeSpan += Time.deltaTime;

			if (timeSpan > checkTime) {
				moveSpeed = Random.Range(15, 20);
				Instantiate(prefab, new Vector3(pos.x, pos.y, pos.z), Quaternion.Euler(rot.x, 90f, rot.z));
				transform.Translate (Vector3.back *Time.deltaTime* moveSpeed);
				timeSpan = 0;
			}
		} 

		else if (currentLoadedScene.name.Equals ("level3")) {
			if (moveSpeed < 15)
				checkTime = 4f;
			else if (moveSpeed < 20)
				checkTime = 3f;
			else
				checkTime = 2f;

			transform.Translate (Vector3.back *Time.deltaTime* moveSpeed);
			timeSpan += Time.deltaTime;

			if (timeSpan > checkTime) {
				moveSpeed = Random.Range(20, 25);
				Instantiate(prefab, new Vector3(pos.x, pos.y, pos.z), Quaternion.Euler(rot.x, 90f, rot.z));
				transform.Translate (Vector3.back *Time.deltaTime* moveSpeed);
				timeSpan = 0;
			}
		}
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.CompareTag("Respawn")) {
			Destroy (gameObject);
		}
	}

	void OnTriggerExit(Collider col) {
	}
}