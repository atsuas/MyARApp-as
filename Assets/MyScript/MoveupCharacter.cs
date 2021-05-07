using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveupCharacter : MonoBehaviour
{
    private float speed = 0.1f; //キャラクターが移動する速さ

    void Update()
    {
        //キャラクターが箱から出たら停止する
        if (transform.localPosition.y < 0f)
        {
            //上方向に移動させる
            transform.localPosition += transform.up * speed * Time.deltaTime;
        }
    }
}
