using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text timerText;
	public static float time;
	public static int miss=0;
	public bool goal=false;
	string timetext;


    void Start()
	{
		miss = 0;
		time = 0;


    }
	
	// Update is called once per frame
	void Update () {
		if (goal == false) {
			time += Time.deltaTime;
			timetext = time.ToString ("F1");
			timerText.text = ("Time:"+timetext+" Miss:"+miss);
		}
	}
}
