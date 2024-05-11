using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //相対距離
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        //Unityちゃんとの相対距離を求める
        offset = transform.position - unitychan.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //新しい位置の数値を代入
        transform.position = unitychan.transform.position + offset;

        
    }
}
