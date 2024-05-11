using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CapsuleCollider��Rigidbody��ǉ�
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{

    //�ړ��X�s�[�h
    [SerializeField] float speed = 2f;

    //Animator������
    private Animator animator;

    //Main Camera������
    [SerializeField] Transform cam;

    //Rigidbody������
    Rigidbody rb;
    //Capsule Collider������
    CapsuleCollider caps;

    void Start()
    {
        //Animator�R���|�[�l���g���擾
        animator = GetComponent<Animator>();

        //Rigidbody�R���|�[�l���g���擾
        rb = GetComponent<Rigidbody>();
        //Rigidbody��Constraints��3�Ƃ��`�F�b�N�����
        //����ɉ�]���Ȃ��悤�ɂ���
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        //CapsuleCollider�R���|�[�l���g���擾
        caps = GetComponent<CapsuleCollider>();
        //CapsuleCollider�̒��S�̈ʒu�����߂�
        caps.center = new Vector3(0, 0.76f, 0);
        //CapsuleCollider�̔��a�����߂�
        caps.radius = 0.23f;
        //CapsuleCollider�̍��������߂�
        caps.height = 1.6f;
    }

    void Update()
    {
        //A�ED�L�[�A�����L�[�ŉ��ړ�
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;

        //W�ES�L�[�A�����L�[�őO��ړ�
        float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        //AnimatorController��Parameters�ɐ��l�𑗂���
        //�A�j���[�V�������o��
        animator.SetFloat("X", x * 50);
        animator.SetFloat("Y", z * 50);

        //�O�ړ��̎����������]����������
        if (z > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x,
                    cam.eulerAngles.y, transform.rotation.z));
        }

        //x��z�̐��l�Ɋ�Â��Ĉړ�
        transform.position += transform.forward * z + transform.right * x;
    }
}