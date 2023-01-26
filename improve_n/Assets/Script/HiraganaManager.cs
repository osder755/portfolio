using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HiraganaManager : MonoBehaviour
{

    int Player_Order = 1;
    public static int miss=0;
    Vector2 min, max;
    GameObject playerobj, kana1obj, kana2obj, kana3obj;
    Timer timer;
    string[] hiragana_array = {
        "0",
        "あ",
        "い",
        "う",
        "え",
        "お",
        "か",
        "き",
        "く",
        "け",
        "こ",
        "さ",
        "し",
        "す",
        "せ",
        "そ",
        "た",
        "ち",
        "つ",
        "て",
        "と",
        "な",
        "に",
        "ぬ",
        "ね",
        "の",
        "は",
        "ひ",
        "ふ",
        "へ",
        "ほ",
        "ま",
        "み",
        "む",
        "め",
        "も",
        "や",
        "ゆ",
        "よ",
        "ら",
        "り",
        "る",
        "れ",
        "ろ",
        "わ",
        "を",
        "ん"
    };


    // Start is called before the first frame update
    void Start()
    {
        playerobj = GameObject.Find("Player");
        kana1obj = GameObject.Find("hiragana1");
        kana2obj = GameObject.Find("hiragana2");
        kana3obj = GameObject.Find("hiragana3");

        timer = GameObject.Find("Timer").GetComponent<Timer>();

        // 画面左下のワールド座標をビューポートから取得-0.6
        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // 画面右上のワールド座標をビューポートから取得-0.6
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        ReplaceHiragana(kana1obj);
        ReplaceHiragana(kana2obj);
        ReplaceHiragana(kana3obj);

        DisplayHiragana(kana1obj);
        DisplayHiragana(kana2obj);
        DisplayHiragana(kana3obj);

    }

    public void ReplaceHiragana(GameObject hiragana)
    {
        //if (hiragana == null || hiragana==kana1obj) Debug.Log("replace null");
        Vector3 pos;
        float dis;
        float dis12;
        float dis13;
        float dis23;


        if (hiragana == kana1obj)
        {
            do
            {
                pos = new Vector3(Random.Range(min.x + 0.5f, max.x - 0.5f), Random.Range(-2.0f, 3.7f), 0);
                dis = Vector3.Distance(pos, playerobj.transform.position);
                dis12 = Vector3.Distance(pos, kana2obj.transform.position);
                dis13 = Vector3.Distance(pos, kana3obj.transform.position);
            } while (dis12 < 1.4f || dis13 < 1.4f || dis < 1.4f);
            kana1obj.transform.position = pos;
        }
        else if (hiragana == kana2obj)
        {
            do
            {
                pos = new Vector3(Random.Range(min.x + 0.5f, max.x - 0.5f), Random.Range(-2.0f, 3.7f), 0);
                dis = Vector3.Distance(pos, playerobj.transform.position);
                dis12 = Vector3.Distance(pos, kana1obj.transform.position);
                dis23 = Vector3.Distance(pos, kana3obj.transform.position);
            } while (dis12 < 1.4f || dis23 < 1.4f || dis < 1.4f);
            kana2obj.transform.position = pos;

        }
        else if (hiragana == kana3obj)
        {
            do
            {
                pos = new Vector3(Random.Range(min.x + 0.5f, max.x - 0.5f), Random.Range(-2.0f, 3.7f), 0);
                dis = Vector3.Distance(pos, playerobj.transform.position);
                dis13 = Vector3.Distance(pos, kana1obj.transform.position);
                dis23 = Vector3.Distance(pos, kana2obj.transform.position);
            } while (dis13 < 1.4f || dis23 < 1.4f || dis < 1.4f);
            kana3obj.transform.position = pos;
        }

    }

    void DisplayHiragana(GameObject hiragana)
    {
        //if (hiragana == null || hiragana == kana1obj) Debug.Log("displayでnull");
        playerobj.GetComponent<TextMesh>().text = hiragana_array[Player_Order];

        int Order = hiragana.GetComponent<HiraganaOrder>().Order;

        if (Order == 49)
        {
            Destroy(hiragana);
            Clear();
        }

        if (Order >= 47)
        {
            Destroy(hiragana);
            return;
            
        }

        hiragana.GetComponent<HiraganaOrder>().Order = Order;
        hiragana.GetComponent<TextMesh>().text = hiragana_array[Order];
        
    }


    public void Judge(GameObject hiragana)
    {
        //if (hiragana == null || hiragana == kana1obj) Debug.Log("judgeでnull");
        //ん=46
        int Order = hiragana.GetComponent<HiraganaOrder>().Order;


        if (Player_Order + 1 != Order)
        {
            if (miss < 99)
            {
                Timer.miss++;
            }
            return;
        }

        Player_Order++;
        hiragana.GetComponent<HiraganaOrder>().Order += 3;
        DisplayHiragana(hiragana);
        ReplaceHiragana(hiragana);
        

    }



    // Update is called once per frame
    void Clear()
    {
        timer.goal = true;
        Debug.Log("clear! miss:" + Timer.miss + " time:" + Timer.time);
        GameObject.Find("background").GetComponent<whistle>().Whistle();
        Invoke("Load", 2);
    }

    void Load()
    {

        SceneManager.LoadScene("clearscene");
    }
}
