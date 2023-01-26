using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PageManager : MonoBehaviour {

	int Page=2;
	Image RI;
	Image LI;
    public Sprite Good_R;
    public Sprite Good_L;
    public Sprite Miss;
    public Text rule;

	// Use this for initialization
	void Start () {
        RI = GameObject.Find("RightImage").GetComponent<Image>();
        LI = GameObject.Find("LeftImage").GetComponent<Image>();
        Control(Page);
    }



    public void Preview()
    {
        Page--;
        Control(Page);
    }

    public void Next()
    {
        Page++;
        Control(Page);
    }

    void Control(int x){

		switch (x) {
		case 1:
			SceneManager.LoadScene ("title");
			break;
		case 2:
                RI.sprite = Good_R;
                LI.sprite = Good_L;
			rule.text = 
                    "自分のひらがなを操作して\n" +
				    "「あ」を「ん」にしよう！\n" +
				    "自分の次のひらがなを\n" +
				    "捕まえると成長できる！\n" +
				    "素早く動かして誰よりも\n" +
				    "早く「ん」になろう！";
			GetComponent<AudioSource> ().Play ();

			break;
		case 3:
                RI.sprite = null;
                LI.sprite = Miss;
			rule.text = 
                    "間違ったひらがなに\n" +
                    "触れてしまうとMISS！\n" +
			        "タイムが\n" +
                    "5秒プラスされてしまう！";
			GetComponent<AudioSource> ().Play ();

			break;
		case 4:
			SceneManager.LoadScene ("Count");
			break;
		default:
			break;
		}
	}

}
