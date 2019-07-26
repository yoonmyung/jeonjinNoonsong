using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour {
	//캐릭터 관련 변수들
	Animator anim;
	public GameObject thePlayer;

	//목숨 관련 변수들
	public GameObject heart1;
	public GameObject heart2;
	public GameObject heart3;
	public static bool isUnBeatTime = false;
	public Canvas canvas;
	public int maxHealth = 3;
	bool isCollider = false;
	int current_health = 3;

	//커피숍 이벤트 관련 변수들
	public Transform loadingBar;
	public Transform loadingText;
	[SerializeField] private float currentAmount;
	[SerializeField] private float speed;
	public static bool coffee = false;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		isCollider = false;
		current_health = maxHealth;
	}

	void FixedUpdate() {
		if (current_health == 0)
			return;
	}

	// Update is called once per frame
	void Update () {
		Bounce bounceScript = thePlayer.GetComponent<Bounce> ();

		if (bounceScript.justJump == true) {
			anim.SetBool ("Jump", true);
		} 
		else {
			anim.SetBool ("Jump", false);
		}

		if (Input.GetButtonDown ("right")) {
			gameObject.transform.rotation = Quaternion.Euler (0, 90, 0);
		}

		if (Input.GetButtonDown ("left")) {
			gameObject.transform.rotation = Quaternion.Euler (0, -90, 0);
		}

		if (Input.GetButtonDown ("up")) {
			gameObject.transform.rotation = Quaternion.Euler (0, 0, 0);
		}

		if (Input.GetButtonDown ("down")) {
			gameObject.transform.rotation = Quaternion.Euler (0, 180, 0);
		}

		if (isCollider && Input.GetKey(KeyCode.Space)) {
			takeCoffee ();
		}

		if (current_health == 0) {
			SceneManager.LoadScene ("gameOver");
		}
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.CompareTag ("car")) {
			reduceLife (current_health);
		} 

		else if (col.gameObject.CompareTag ("line1")) {
			reduceLife (current_health);
		}

		else if (col.gameObject.CompareTag ("line2")) {
			reduceLife (current_health);
		}

		else if (col.gameObject.CompareTag ("line3")) {
			reduceLife (current_health);
		}

		else if (col.gameObject.CompareTag ("line4")) {
			reduceLife (current_health);
		}

		else if (col.gameObject.CompareTag ("line5")) {
			reduceLife (current_health);
		}
	}

	void OnCollisionExit(Collision col) {
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.CompareTag ("cafe"))
			isCollider = true;

		else if (col.gameObject.CompareTag ("Finish")) {
			if (coffee) {
				SceneManager.LoadScene ("clear");
			} 

			else {
				SceneManager.LoadScene ("gameOver");
			}
		}
	}

	void OnTriggerExit(Collider col) {
	}

	IEnumerator UnBeatTime() {
		int countTime = 0;

		while (countTime < 10) {
			yield return new WaitForSeconds (0.2f);
			countTime++;
		}

		isUnBeatTime = false;
		yield return null;
	}

	void reduceLife(int current_heart) {
		if (current_health == 3) {
			isUnBeatTime = true;
			StartCoroutine ("UnBeatTime");
			heart3.SetActive (false);
		} else if (current_health == 2) {
			isUnBeatTime = true;
			StartCoroutine ("UnBeatTime");
			heart2.SetActive (false);
		}
		else {
			heart1.SetActive (false);
			SceneManager.LoadScene ("gameOver");
		}
		current_health--;
	}

	void takeCoffee() {
		if (currentAmount < 100) {
			currentAmount += speed * Time.deltaTime;
		} else {
			loadingText.GetComponent<Text> ().text = "TAKE\nCOFFEE!";
		}
		loadingBar.GetComponent<Image> ().fillAmount = currentAmount / 100;

		if(currentAmount >= 100)
			coffee = true;
	}
}
