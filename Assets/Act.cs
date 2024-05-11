//
// Mecanimのアニメーションデータが、原点で移動しない場合の Rigidbody付きコントローラ
// サンプル
// 2014/03/13 N.Kobyasahi
//
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PlayerControll : MonoBehaviour
{
    // アニメーション再生速度設定
    public float animSpeed = 1.0f;
    // a smoothing setting for camera motion
    public float lookSmoother = 1f;           

    // 以下キャラクターコントローラ用パラメタ
    // 前進速度
    public float forwardSpeed = 6.0f;
    // 後退速度
    public float backwardSpeed = 5.0f;
    // 旋回速度
    public float rotateSpeed = 0.3f;
    //RigidBodyの取得
    private Rigidbody rb;
    // キャラクターコントローラ（カプセルコライダ）の移動量
    private Vector3 velocity;
    // キャラにアタッチされるアニメーターへの参照
    private Animator Anim;
    //スコアを表示
    private GameObject scoreText;
    //得点
    private int score = 0;
    
    
    void Start()
    {
        // Animatorコンポーネントを取得する
        Anim = GetComponent<Animator>();
        // RigidBodyコンポーネントを取得する
        rb = GetComponent<Rigidbody>();
        //シーン中のscoreTextを取得
        this.scoreText = GameObject.Find("ScoreText");
        
    }

    void Update()
    {
        // 入力デバイスの水平軸をhで定義
        float h = Input.GetAxis("Horizontal");
        // 入力デバイスの垂直軸をvで定義
        float v = Input.GetAxis("Vertical");
        // Animator側で設定している"Speed"パラメタにvを渡す
        Anim.SetFloat("Speed", v);
        // Animator側で設定している"Direction"パラメタにhを渡す
        Anim.SetFloat("Direction", h);
        // Animatorのモーション再生速度に animSpeedを設定する
        Anim.speed = animSpeed;
        //ジャンプ中に重力を切るので、それ以外は重力の影響を受けるようにする
        rb.useGravity = true;


        // 以下、キャラクターの移動処理
        // 上下のキー入力からZ軸方向の移動量を取得
        velocity = new Vector3(0, 0, v);        
        // キャラクターのローカル空間での方向に変換
        velocity = transform.TransformDirection(velocity);
        //以下のvの閾値は、Mecanim側のトランジションと一緒に調整する
        if (v > 0.1)
        {
            // 移動速度を掛ける
            velocity *= forwardSpeed;      
        }
        else if (v < -0.1)
        {
            // 移動速度を掛ける
            velocity *= backwardSpeed;  
        }


        // 上下のキー入力でキャラクターを移動させる
        transform.localPosition += velocity * Time.deltaTime;

        // 左右のキー入力でキャラクタをY軸で旋回させる
        transform.Rotate(0, h * rotateSpeed, 0);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector3.forward);
        }
       
    }
    void OnCollisionEnter(Collision other)
    {
        //ストーンに接触した際の処理
        if (other.gameObject.CompareTag("StonePrefabTag"))
        {
            //ストーンを破壊
            Destroy(other.gameObject);

            //スコアを加算
            this.score += 10;
            //スコアを表示
            this.scoreText.GetComponent<Text>().text = "Score" + this.score + "pt";
            //スコアが100ptに達した場合
            if (this.score >= 100)
            {
                //GameSystemのGameClear関数を呼び出して画面上に表示
                GameObject.Find("Canvas").GetComponent<GameSystem>().GameClear();
            }
        }
        

    }

}

