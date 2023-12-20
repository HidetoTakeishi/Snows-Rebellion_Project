using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowPitching : MonoBehaviour
{
    [Header("��΂���ʂ̃v���t�@�u")]
    public GameObject snowballPrefab;

    [Header("��΂����e�̃v���t�@�u")]
    public GameObject bombPrefab;

    [Header("��΂���ʂ̐���"), SerializeField]
    public float throwForce = 10.0f;

    public int bombCount = 0;        // ���e�c�e��
    public int snowballCount = 30;   // ��ʎc�e��

    private bool useBomb = false;   // ���e���g�����ǂ���

    public void ThrowSnowball()
    {
        Camera mainCamera = Camera.main;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if(snowballCount > 0)   // ��ʂ��c���Ă���ꍇ
        {
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Vector3 throwDirection = (hitInfo.point - transform.position).normalized;

                if(useBomb)
                {
                    GameObject bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);   // ���e�𐶐�

                    Rigidbody rb = bomb.GetComponent<Rigidbody>();
                    rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

                    bombCount--;   // ���e�������
                }
                else
                {
                    GameObject snowball = Instantiate(snowballPrefab, transform.position, Quaternion.identity);   // ��ʂ𐶐�

                    Rigidbody rb = snowball.GetComponent<Rigidbody>();
                    rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

                    snowballCount--;   // ��ʂ������
                }
            }
        }
    }

    public void SwitchWeapon()   // ����̐؂�ւ�����
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) useBomb = !useBomb;
    }
}
