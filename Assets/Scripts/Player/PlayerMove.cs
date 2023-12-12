using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("�������̈ړ����x"), SerializeField]
    private float xSpeed = 0;

    [Header("�������̈ړ�����"), SerializeField]
    private float xMoveLimit = 1;

    // Start is called before the first frame update
    void Start()
    {
        // �l�̒���
        if (xSpeed <= 0) xSpeed = 1;
        if (xMoveLimit <= 0) xMoveLimit = 1;
    }

    public void MoveHorizontal()   // ���E�ړ����s������
    {
        float moveX = Input.GetAxis("Horizontal") * xSpeed;   // A D�L�[�̓��͂ō��E�ړ�
        transform.position += new Vector3(moveX, 0, 0) * Time.deltaTime;   // �ړ��ʂ�������

        Vector3 playerPos = transform.position;
        playerPos.x = Mathf.Clamp(playerPos.x, -xMoveLimit, xMoveLimit);   // X���W�𐧌�
        transform.position = playerPos;   // �����������W��K�p
    }
}
