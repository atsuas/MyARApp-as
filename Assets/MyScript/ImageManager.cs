using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageManager : MonoBehaviour
{
    //イメージトラッキングの結果を取得するためのクラス
    ARTrackedImageManager m_TrackedImageManager;

    //画像に重ねて表示するPrefabのList
    [SerializeField]
    private List<GameObject> prefabs;

    void Start()
    {
        //GameObjectにアタッチされているARTrackedImageManagerを取得
        m_TrackedImageManager = GetComponent<ARTrackedImageManager>();

        //ARTrackedImageの変更時に実行する関数をセット
        m_TrackedImageManager.trackedImagesChanged += OnTrackedImageChanged;
    }

    //ARTrackedImageの変更時に実行される関数
    void OnTrackedImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        //新たに追加(検知)された画像に対して実行
        foreach (var trackedImage in eventArgs.added)
        {
            //ReferenceImage の Name が"image1"の画像に対する処理
            if (trackedImage.referenceImage.name == "image1")
            {
                //検知した画像を parent にして、Prefab から GameObject を作成する
                Instantiate(prefabs[0], trackedImage.transform);
            }

            //ReferenceImage の Name が"image2"の画像に対する処理
            if (trackedImage.referenceImage.name == "image2")
            {
                //検知した画像を parent にして、Prefab から GameObject を作成する
                Instantiate(prefabs[1], trackedImage.transform);
            }
        }
    }

}
