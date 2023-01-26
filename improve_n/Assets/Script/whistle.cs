using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whistle : MonoBehaviour {

	public void Whistle(){

		GetComponent<AudioSource> ().Play ();

	}

}
