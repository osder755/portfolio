using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour {

	public static float goaltime;
	//GameObject kana1;
	// Use this for initialization
	void Start () {
        //kana1 = GameObject.Find("hiragana1");
        //miss = 0;

    }
	
	// Update is called once per frame
	void Update () {


		if (Application.platform == RuntimePlatform.Android && Input.GetKeyDown (KeyCode.Escape)) {
			Invoke ("title", 0.3f);
		}
	}

	void title(){
		SceneManager.LoadScene ("title");
	}

    void OnTriggerEnter2D(Collider2D c)
	{
		//if (c == null || c==kana1) Debug.Log("playerでNULL");
		GameObject hiragana = c.gameObject;

		HiraganaManager HM = GameObject.Find("HiraganaManager").GetComponent<HiraganaManager>();
		HM.Judge(hiragana);


    }

}
