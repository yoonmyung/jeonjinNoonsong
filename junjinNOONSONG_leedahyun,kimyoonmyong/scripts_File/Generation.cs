using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour {

	public GameObject Water;
	public GameObject Road;
	public GameObject Grass;

	int firstRand;
	int secondRand;
	int disPlayer = 18;

	Vector3 intPos = new Vector3(0, 0, 0);

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("up")) {
			firstRand = Random.Range (1, 4);
			if (firstRand == 1) {
				secondRand = Random.Range (1, 8);
				for (int i = 0; i < secondRand; i++) {
					intPos = new Vector3 (disPlayer, 0, 0);
					disPlayer += 1;
					GameObject GrassIns = Instantiate (Grass) as GameObject;
					GrassIns.transform.position = intPos;
				}
			}

			if (firstRand == 2) {
				secondRand = Random.Range (1, 8);
				for (int i = 0; i < secondRand; i++) {
					intPos = new Vector3 (disPlayer, -0.1F, 0);
					disPlayer += 1;
					GameObject RoadIns = Instantiate (Road) as GameObject;
					RoadIns.transform.position = intPos;
				}
			}

			if (firstRand == 3) {
				secondRand = Random.Range (1, 8);
				for (int i = 0; i < secondRand; i++) {
					intPos = new Vector3 (disPlayer, -0.2F, 0);
					disPlayer += 1;
					GameObject WaterIns = Instantiate (Water) as GameObject;
					WaterIns.transform.position = intPos;
				}
			}
		}
	}
}
