using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    

    //�Q�[���N���A���ɕ\������e�L�X�g
    private GameObject stateText;

    //�Q�[���N���A�̔���
    private bool isGameClear = false;

    // Start is called before the first frame update
    void Start()
    {
        //�V�[������stateText���擾
        this.stateText = GameObject.Find("GameResultText");
    }   
   
    
    // Update is called once per frame
    void Update()
    {
        //�Q�[���N���A�̏ꍇ
        if (this.isGameClear == true)
        {
            //�X�y�[�X�L�[�������ƃ��X�^�[�g
            if (Input.GetKey(KeyCode.Space))
            {
                //SampleScene��ǂݍ���
                SceneManager.LoadScene("SampleScene");
            }
        }

    }
    public void GameClear() 
    {
        //�Q�[���N���A�̍ہA��ʏ�ɃQ�[���N���A��\��
        this.stateText.GetComponent<Text>().text = "Game Clear";
        this.isGameClear = true;
    }
}
