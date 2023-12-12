using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum : MonoBehaviour
{
    [Header("�z�����ޑ��x"), SerializeField]
    private float vacuumSpeed = 1;

    [Header("�v���C���[�̍��W"), SerializeField]
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("SnowBall Obj"))
        {
            Vector3 direction = (player.position - other.transform.position).normalized;   // �x�N�g���̌v�Z�����Đ��K��
            other.transform.position += direction * vacuumSpeed;   // ���K�������x�N�g���ɋz�����x���|�����킹�ēK�p
        }
    }
}
