using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowPitching : MonoBehaviour
{
    [Header("��΂���ʂ̃v���t�@�u")]
    public GameObject snowballPrefab;

    public Transform throwPoint;

    [Header("��΂���ʂ̐���"), SerializeField]
    public float throwForce = 10.0f;

    public float ammoCount = 30;   // �c�e��

    private void Start()
    {

    }

    public void ThrowSnowball()
    {
        Camera mainCamera = Camera.main;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if(ammoCount > 0)   // ��ʂ��c���Ă���ꍇ
        {
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Vector3 throwDirection = (hitInfo.point - transform.position).normalized;

                GameObject snowball = Instantiate(snowballPrefab, transform.position, Quaternion.identity);   // ��ʂ𐶐�

                Rigidbody rb = snowball.GetComponent<Rigidbody>();
                rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

                ammoCount--;   // ��ʂ������
            }
        }
    }
}
