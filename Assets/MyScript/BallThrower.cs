using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BallThrower : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab;
    //ボールの速さ
    float shotSpeed = 10.0f;
    void Update()
    {
        //画面がタッチされたら処理を行う
        if (Input.touchCount > 0)
        {
            //画面タッチの情報を取得する
            Touch touch = Input.GetTouch(0);
            //画面タッチの開始時のみ処理を行う
            if (touch.phase == TouchPhase.Began)
            {
                //ボールを生成する
                GameObject ball = Instantiate(ballPrefab, Camera.main.transform);
                //ボールにカメラ前方への速度を与える
                ball.GetComponent<Rigidbody>().velocity
                = Camera.main.transform.forward * shotSpeed;
            }
        }
    }
}
