using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bird : MonoBehaviour
{
    // �~�̔��a��ݒ肵�܂��B
    public float radius = 10f;

    // �����ʒu���擾���A������ێ����܂��B
    Vector3 initPos;

    void Start()
    {
        // �����ʒu��ێ����܂��B
        //initPos = gameObject.transform.position;
    }

    void Update()
    {
        CalcPosition();
    }

    void CalcPosition()
    {
        // �ʑ����v�Z���܂��B
        float phase = Time.time * 1 * Mathf.PI;

        // ���݂̈ʒu���v�Z���܂��B
        //float xPos = radius * Mathf.Cos(phase);
        float yPos = radius * Mathf.Sin(phase);

        // �Q�[���I�u�W�F�N�g�̈ʒu��ݒ肵�܂��B
        //Vector3 pos = new Vector3(initPos.x, yPos, initPos.z);
        gameObject.transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }
}
