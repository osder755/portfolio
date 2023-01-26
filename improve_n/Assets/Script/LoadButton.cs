using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadButton : MonoBehaviour {

	int page=2;
	PageManager PM;

	// Use this for initialization
	void Start () {
		Input.backButtonLeavesApp = false;
		PM = GameObject.Find("PageManager").GetComponent<PageManager> ();
	}


	public void Nextload(){
		//page = PM.xx;
		//page++;
		//PM.xx=page;
		PM.Next ();

	}

	public void Previewload(){
        //page = PM.xx;
        //page--;
		//PM.xx = page;
		PM.Preview ();
	}


		
}
