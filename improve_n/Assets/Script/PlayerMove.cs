using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    Vector2 max;
    Vector2 min;
    Vector3 playerPos;
    Vector3 mousePos;


    // Start is called before the first frame update
    void Start()
    {
        // 画面左下のワールド座標をビューポートから取得-0.6
        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // 画面右上のワールド座標をビューポートから取得-0.6
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Update()
    {
        TouchControl();
        Clamp();
    }

    void Clamp()
    {
        // プレイヤーの座標を取得
        Vector2 player_pos = transform.position;

        // プレイヤーの位置が画面内に収まるように制限をかける
        player_pos.x = Mathf.Clamp(player_pos.x, min.x, max.x);
        player_pos.y = Mathf.Clamp(player_pos.y, min.y, max.y);

        transform.position = player_pos;
    }

    void TouchControl()
    {

        if (Input.GetMouseButtonDown(0))
        {
            playerPos = this.transform.position;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {

            Vector3 prePos = this.transform.position;
            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - mousePos;

            //タッチ対応デバイス向け、1本目の指にのみ反応
            if (Input.touchSupported)
            {
                diff = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position) - mousePos;
            }

            diff.z = 0.0f;
            this.transform.position = playerPos + diff;

        }

        if (Input.GetMouseButtonUp(0))
        {
            playerPos = Vector3.zero;
            mousePos = Vector3.zero;
        }
    }
}
