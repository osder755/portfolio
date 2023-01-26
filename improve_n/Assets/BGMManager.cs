using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private void Awake()
    {
        if (GameObject.Find("BGM_Origin")!=null)
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        this.name = "BGM_Origin";
        DontDestroyOnLoad(this);
    }

}
