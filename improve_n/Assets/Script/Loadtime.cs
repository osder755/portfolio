using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class Loadtime : MonoBehaviour {

	public Text textc;
	public Text highscoretext;
    float time=0;
	int miss=0;
	float point;
	float highscore;

	// Use this for initialization
	void Start () {
		highscore = PlayerPrefs.GetFloat ("key", 1000);
		time = Timer.time;
		miss = Timer.miss;
		point = Mathf.Ceil(time*10)/10 + miss * 5;
		textc.text = ("Time:"+time.ToString ("F1")+"\nMiss:"+miss+"\nScore:"+point.ToString("F1"));

		if (point < highscore) {
			PlayerPrefs.SetFloat ("key", point);
			PlayerPrefs.Save ();
			highscoretext.text = "High Score!!";
		}
	}
	

}
