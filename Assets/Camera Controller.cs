using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Unity�����̃I�u�W�F�N�g
    private GameObject unitychan;
    //���΋���
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //Unity�����̃I�u�W�F�N�g���擾
        this.unitychan = GameObject.Find("unitychan");
        //Unity�����Ƃ̑��΋��������߂�
        offset = transform.position - unitychan.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //�V�����ʒu�̐��l����
        transform.position = unitychan.transform.position + offset;

        
    }
}
