using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PedestrianController : MonoBehaviour {
	float timeSpan1;
	float timeSpan2;
	float timeSpan3;
	float checkTime;
	float respawnTime;
	public Transform prefab;
	float x, z;
	Scene currentLoadedScene;

	// Use this for initialization
	void Start () {
		timeSpan1 = 0.0f;	//행인 간 전진 간격
		timeSpan2 = 0.0f;	//리스폰 간격
		timeSpan3 = 0.0f;	//사람 몰림 현상 방지
		respawnTime = Random.Range (15f, 25f);
		checkTime = Random.Range(0.2f, 0.7f);
		currentLoadedScene = SceneManager.GetActiveScene ();
	}
	
	// Update is called once per frame
	void Update () {
		if(currentLoadedScene.name.Equals("main")) {
			if (checkTime < 0.3f)
				respawnTime = Random.Range (15f, 18f);
			else if (checkTime < 0.6f)
				respawnTime = Random.Range (17f, 20f);
			else
				respawnTime = Random.Range (20f, 25f);
			
			timeSpan1 += Time.deltaTime;
			timeSpan2 += Time.deltaTime;
			timeSpan3 += Time.deltaTime;

			if (timeSpan1 > checkTime) {
				transform.position += new Vector3 (1f, 0, 0);
				timeSpan1 = 0;
			}

			if (timeSpan2 > respawnTime) {
				if (gameObject.CompareTag ("line1")) {
					x = Random.Range (-41, -32);
					z = Random.Range (10, 36);
				}

				if (gameObject.CompareTag ("line2")) {
					x = Random.Range (-41, -32);
					z = Random.Range (64, 84);
				}

				if (gameObject.CompareTag ("line3")) {
					x = Random.Range (-41, -32);
					z = Random.Range (115, 120);
				}

				if (gameObject.CompareTag ("line4")) {
					x = Random.Range (-41, -23);
					z = 237;
				}

				if (gameObject.CompareTag ("line5")) {
					x = Random.Range (-41, -32);
					z = Random.Range (318, 330);
				}
			
				Instantiate (prefab, new Vector3 (x, 0, z), Quaternion.Euler (0, 90f, 0));
				timeSpan2 = 0;
			}

			if (timeSpan3 > 28) {
				Destroy (gameObject);
				timeSpan3 = 0;
			}
		} 

		else if (currentLoadedScene.name.Equals("level2")) {
			if (checkTime < 0.3f)
				respawnTime = Random.Range (15f, 18f);
			else if (checkTime < 0.6f)
				respawnTime = Random.Range (17f, 20f);
			else
				respawnTime = Random.Range (20f, 25f);

			timeSpan1 += Time.deltaTime;
			timeSpan2 += Time.deltaTime;
			timeSpan3 += Time.deltaTime;

			if (timeSpan1 > checkTime) {
				transform.position += new Vector3 (2f, 0, 0);
				timeSpan1 = 0;
			}

			if (timeSpan2 > respawnTime/2) {
				if (gameObject.CompareTag ("line1")) {
					x = Random.Range (-41, -32);
					z = Random.Range (10, 36);
				}

				if (gameObject.CompareTag ("line2")) {
					x = Random.Range (-41, -32);
					z = Random.Range (64, 84);
				}

				if (gameObject.CompareTag ("line3")) {
					x = Random.Range (-41, -32);
					z = Random.Range (115, 120);
				}

				if (gameObject.CompareTag ("line4")) {
					x = Random.Range (-41, -23);
					z = 237;
				}

				if (gameObject.CompareTag ("line5")) {
					x = Random.Range (-41, -32);
					z = Random.Range (318, 330);
				}

				Instantiate (prefab, new Vector3 (x, 0, z), Quaternion.Euler (0, 90f, 0));
				timeSpan2 = 0;
			}

			if (timeSpan3 > 14) {
				Destroy (gameObject);
				timeSpan3 = 0;
			}
		} 

		else if (currentLoadedScene.name.Equals("level3")) {
			if (checkTime < 0.3f)
				respawnTime = Random.Range (15f, 18f);
			else if (checkTime < 0.6f)
				respawnTime = Random.Range (17f, 20f);
			else
				respawnTime = Random.Range (20f, 25f);

			timeSpan1 += Time.deltaTime;
			timeSpan2 += Time.deltaTime;
			timeSpan3 += Time.deltaTime;

			if (timeSpan1 > checkTime) {
				transform.position += new Vector3 (3f, 0, 0);
				timeSpan1 = 0;
			}

			if (timeSpan2 > respawnTime/3) {
				if (gameObject.CompareTag ("line1")) {
					x = Random.Range (-41, -32);
					z = Random.Range (10, 36);
				}

				if (gameObject.CompareTag ("line2")) {
					x = Random.Range (-41, -32);
					z = Random.Range (64, 84);
				}

				if (gameObject.CompareTag ("line3")) {
					x = Random.Range (-41, -32);
					z = Random.Range (115, 120);
				}

				if (gameObject.CompareTag ("line4")) {
					x = Random.Range (-41, -23);
					z = 237;
				}

				if (gameObject.CompareTag ("line5")) {
					x = Random.Range (-41, -32);
					z = Random.Range (318, 330);
				}

				Instantiate (prefab, new Vector3 (x, 0, z), Quaternion.Euler (0, 90f, 0));
				timeSpan2 = 0;
			}

			if (timeSpan3 > 9) {
				Destroy (gameObject);
				timeSpan3 = 0;
			}
		}
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.CompareTag ("Respawn"))
			Destroy (gameObject);
	}

	void OnTriggerExit(Collider col) {
	}
}
