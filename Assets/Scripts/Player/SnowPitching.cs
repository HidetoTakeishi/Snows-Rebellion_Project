using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowPitching : MonoBehaviour
{
    [Header("飛ばす雪玉のプレファブ")]
    public GameObject snowballPrefab;

    public Transform throwPoint;

    [Header("飛ばす雪玉の勢い"), SerializeField]
    public float throwForce = 10.0f;

    public float ammoCount = 30;   // 残弾数

    private void Start()
    {

    }

    public void ThrowSnowball()
    {
        Camera mainCamera = Camera.main;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if(ammoCount > 0)   // 雪玉が残っている場合
        {
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Vector3 throwDirection = (hitInfo.point - transform.position).normalized;

                GameObject snowball = Instantiate(snowballPrefab, transform.position, Quaternion.identity);   // 雪玉を生成

                Rigidbody rb = snowball.GetComponent<Rigidbody>();
                rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

                ammoCount--;   // 雪玉を一個消費
            }
        }
    }
}
