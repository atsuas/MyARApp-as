using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Raycast : MonoBehaviour
{
    //Raycastを実行するためのクラス
    private ARRaycastManager m_RaycastManager;

    //Raycastの結果を格納するList
    private List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

    //キャタクターのPrefab
    [SerializeField]
    private GameObject characterPrefab;
    
    void Start()
    {
        //GameObjectにアタッチされているRaycastManagerを取得
        m_RaycastManager = GetComponent<ARRaycastManager>();
    }

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
                //タッチした方向にRayを飛ばし、平面との衝突判定を行う
                if (m_RaycastManager.Raycast(
                                        touch.position,
                                        hitResults,
                                        TrackableType.PlaneWithinPolygon
                                      ))
                {
                    //最初に交差した平面から姿勢を取得して、GameObjectを生成する
                    Pose hitPose = hitResults[0].pose;
                    GameObject character = Instantiate(
                                                characterPrefab,
                                                hitPose.position,
                                                hitPose.rotation
                        );
                }
                
            }
        }

    }
}
