using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class countdown : MonoBehaviour {

	public Text timerText;

	public float totalTime;
	int seconds;

	// Use this for initialization
	void Start () {
		GetComponent<AudioSource> ().Play ();
	}

	// Update is called once per frame
	void Update () {
	
		totalTime -= Time.deltaTime;
		seconds = (int)totalTime;
		timerText.text = seconds.ToString ();

		if (seconds <= 0) {

			timerText.text = "START!";
			Invoke ("Scene", 1.0f);
		}
	}

	void Scene(){
		SceneManager.LoadScene ("gamescene");
	}

}
