using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    

    //ゲームクリア時に表示するテキスト
    private GameObject stateText;

    //ゲームクリアの判定
    private bool isGameClear = false;

    // Start is called before the first frame update
    void Start()
    {
        //シーン中のstateTextを取得
        this.stateText = GameObject.Find("GameResultText");
    }   
   
    
    // Update is called once per frame
    void Update()
    {
        //ゲームクリアの場合
        if (this.isGameClear == true)
        {
            //スペースキーを押すとリスタート
            if (Input.GetKey(KeyCode.Space))
            {
                //SampleSceneを読み込む
                SceneManager.LoadScene("SampleScene");
            }
        }

    }
    public void GameClear() 
    {
        //ゲームクリアの際、画面上にゲームクリアを表示
        this.stateText.GetComponent<Text>().text = "Game Clear";
        this.isGameClear = true;
    }
}
