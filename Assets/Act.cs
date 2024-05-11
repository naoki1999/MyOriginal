//
// Mecanim�̃A�j���[�V�����f�[�^���A���_�ňړ����Ȃ��ꍇ�� Rigidbody�t���R���g���[��
// �T���v��
// 2014/03/13 N.Kobyasahi
//
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PlayerControll : MonoBehaviour
{
    // �A�j���[�V�����Đ����x�ݒ�
    public float animSpeed = 1.0f;
    // a smoothing setting for camera motion
    public float lookSmoother = 1f;           

    // �ȉ��L�����N�^�[�R���g���[���p�p�����^
    // �O�i���x
    public float forwardSpeed = 6.0f;
    // ��ޑ��x
    public float backwardSpeed = 5.0f;
    // ���񑬓x
    public float rotateSpeed = 0.3f;
    //RigidBody�̎擾
    private Rigidbody rb;
    // �L�����N�^�[�R���g���[���i�J�v�Z���R���C�_�j�̈ړ���
    private Vector3 velocity;
    // �L�����ɃA�^�b�`�����A�j���[�^�[�ւ̎Q��
    private Animator Anim;
    //�X�R�A��\��
    private GameObject scoreText;
    //���_
    private int score = 0;
    
    
    void Start()
    {
        // Animator�R���|�[�l���g���擾����
        Anim = GetComponent<Animator>();
        // RigidBody�R���|�[�l���g���擾����
        rb = GetComponent<Rigidbody>();
        //�V�[������scoreText���擾
        this.scoreText = GameObject.Find("ScoreText");
        
    }

    void Update()
    {
        // ���̓f�o�C�X�̐�������h�Œ�`
        float h = Input.GetAxis("Horizontal");
        // ���̓f�o�C�X�̐�������v�Œ�`
        float v = Input.GetAxis("Vertical");
        // Animator���Őݒ肵�Ă���"Speed"�p�����^��v��n��
        Anim.SetFloat("Speed", v);
        // Animator���Őݒ肵�Ă���"Direction"�p�����^��h��n��
        Anim.SetFloat("Direction", h);
        // Animator�̃��[�V�����Đ����x�� animSpeed��ݒ肷��
        Anim.speed = animSpeed;
        //�W�����v���ɏd�͂�؂�̂ŁA����ȊO�͏d�͂̉e�����󂯂�悤�ɂ���
        rb.useGravity = true;


        // �ȉ��A�L�����N�^�[�̈ړ�����
        // �㉺�̃L�[���͂���Z�������̈ړ��ʂ��擾
        velocity = new Vector3(0, 0, v);        
        // �L�����N�^�[�̃��[�J����Ԃł̕����ɕϊ�
        velocity = transform.TransformDirection(velocity);
        //�ȉ���v��臒l�́AMecanim���̃g�����W�V�����ƈꏏ�ɒ�������
        if (v > 0.1)
        {
            // �ړ����x���|����
            velocity *= forwardSpeed;      
        }
        else if (v < -0.1)
        {
            // �ړ����x���|����
            velocity *= backwardSpeed;  
        }


        // �㉺�̃L�[���͂ŃL�����N�^�[���ړ�������
        transform.localPosition += velocity * Time.deltaTime;

        // ���E�̃L�[���͂ŃL�����N�^��Y���Ő��񂳂���
        transform.Rotate(0, h * rotateSpeed, 0);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector3.forward);
        }
       
    }
    void OnCollisionEnter(Collision other)
    {
        //�X�g�[���ɐڐG�����ۂ̏���
        if (other.gameObject.CompareTag("StonePrefabTag"))
        {
            //�X�g�[����j��
            Destroy(other.gameObject);

            //�X�R�A�����Z
            this.score += 10;
            //�X�R�A��\��
            this.scoreText.GetComponent<Text>().text = "Score" + this.score + "pt";
            //�X�R�A��100pt�ɒB�����ꍇ
            if (this.score >= 100)
            {
                //GameSystem��GameClear�֐����Ăяo���ĉ�ʏ�ɕ\��
                GameObject.Find("Canvas").GetComponent<GameSystem>().GameClear();
            }
        }
        

    }

}

