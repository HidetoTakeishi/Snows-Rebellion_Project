using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowPitching : MonoBehaviour
{
    [Header("��΂���ʂ̃v���t�@�u")]
    public GameObject snowballPrefab;

    [Header("��΂����e�̃v���t�@�u")]
    public GameObject bomb;

    [Header("��΂���ʂ̐���"), SerializeField]
    public float throwForce = 10.0f;

    public int bombCount = 10;        // ���e�c�e��
    public int snowballCount = 30;   // ��ʎc�e��

    [Header("���e�I�𒆂̕\��"), SerializeField]
    private GameObject bombCursor;

    [Header("��ʑI�𒆂̕\��"), SerializeField]
    private GameObject snowballCursor;

    private bool useBomb = false;   // ���e���g����

    void Start()
    {
        bombCursor.SetActive(useBomb);
        snowballCursor.SetActive(!useBomb);
    }

    public void ThrowWeapon()
    {
        Camera mainCamera = Camera.main;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Vector3 throwDirection = (hitInfo.point - transform.position).normalized;

            if (useBomb)
            {
                if(bombCount > 0)
                {
                    GameObject _bomb = Instantiate(bomb, transform.position, Quaternion.identity);   // ��ʂ𐶐�

                    Rigidbody rb = _bomb.GetComponent<Rigidbody>();
                    rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

                    bombCount--;   // ��ʂ������
                }
            }
            else
            {
                if (snowballCount > 0)   // ��ʂ��c���Ă���ꍇ
                {
                    GameObject snowball = Instantiate(snowballPrefab, transform.position, Quaternion.identity);   // ��ʂ𐶐�

                    Rigidbody rb = snowball.GetComponent<Rigidbody>();
                    rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

                    snowballCount--;   // ��ʂ������
                }
            }
        }
    }

    public void SwitchWeapon()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            useBomb = !useBomb;

            if (bombCursor == null || snowballCursor == null) return;

            bombCursor.SetActive(useBomb);
            snowballCursor.SetActive(!useBomb);
        }
    }

    public bool UseBomb
    {
        get { return useBomb; }
    }
}
