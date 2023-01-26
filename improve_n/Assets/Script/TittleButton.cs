using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TittleButton : MonoBehaviour {

	float score;
	public Text highscore;

	void Start(){
		Input.backButtonLeavesApp = true;

		score = PlayerPrefs.GetFloat ("key", -1);

		if (score != -1) {
			highscore.text = "自己ベスト：" + score;
		} else {
			highscore.text = "自己ベスト：--.-";
		}
	}

	void Update(){
		
	}

	public void OnClick(){
		SceneManager.LoadScene ("prologue");
	}

}
