using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class hyouka : MonoBehaviour {

	SpriteRenderer sr;
	public Sprite sugoi;
	public Sprite totemosugoi;
	public Sprite sugokunai;
	public Sprite hutuu;
	public Image n_image;
	float point;

	// Use this for initialization
	void Start () {
		sr = gameObject.GetComponent<SpriteRenderer> ();
		point = Timer.time + Timer.miss * 5;

		Rate(point);

    }


	void Rate(float point)
	{
        if (point <= 0)
        {
            ;
        }
        else if (point < 20)
        {
            n_image.sprite = totemosugoi;
        }
        else if (point < 35)
        {
            n_image.sprite = sugoi;
        }
        else if (point < 50)
        {
            n_image.sprite = hutuu;
        }
        else
        {
            n_image.sprite = sugokunai;
        }
    }

}
