using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	

	public Text timeLabel;
	public float timeCount = 0;

	void Awake(){
		timeCount = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeCount > 0)
			timeCount -= Time.deltaTime;

		timeLabel.text = string.Format ("{0:N2}", timeCount);

		if ((timeCount-1f) <= 0f)
			SceneManager.LoadScene ("gameOver");
	}
}

