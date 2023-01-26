using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearSceneButton : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("title");
    }
}
