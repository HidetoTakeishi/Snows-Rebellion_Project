using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowPitching : MonoBehaviour
{
    public GameManager GameManager;
    public GameObject snowballPrefab;

    public Transform throwPoint;

    [Header("飛ばす雪玉の勢い"), SerializeField]
    public float throwForce = 10.0f;

    private float ammoCount = 30;   // 残弾数

    private bool canThrow = true;

    private void Update()
    {
        if (canThrow && Input.GetMouseButtonDown(0))
        {
            ThrowSnowball();
        }
    }

    void ThrowSnowball()
    {
        Camera mainCamera = Camera.main;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if(ammoCount > 0)   // 雪玉が残っている場合
        {
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Vector3 throwDirection = (hitInfo.point - transform.position).normalized;

                GameObject snowball = Instantiate(snowballPrefab, transform.position, Quaternion.identity);

                Rigidbody rb = snowball.GetComponent<Rigidbody>();
                rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

                ammoCount--;   // 雪玉を一個消費
            }
        }
    }

    public void DisableThrowing()
    {
        canThrow = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SnowMan"))
        {
            GameManager.Dead();
        }
    }

    public float AmmoCount   // 残弾数ゲッター
    {
        get { return ammoCount; }
    }
}
