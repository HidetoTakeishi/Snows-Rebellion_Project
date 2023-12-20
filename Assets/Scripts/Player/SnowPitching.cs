using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowPitching : MonoBehaviour
{
    [Header("飛ばす雪玉のプレファブ")]
    public GameObject snowballPrefab;

    [Header("飛ばす爆弾のプレファブ")]
    public GameObject bombPrefab;

    [Header("飛ばす雪玉の勢い"), SerializeField]
    public float throwForce = 10.0f;

    public int bombCount = 0;        // 爆弾残弾数
    public int snowballCount = 30;   // 雪玉残弾数

    private bool useBomb = false;   // 爆弾を使うかどうか

    public void ThrowSnowball()
    {
        Camera mainCamera = Camera.main;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if(snowballCount > 0)   // 雪玉が残っている場合
        {
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Vector3 throwDirection = (hitInfo.point - transform.position).normalized;

                if(useBomb)
                {
                    GameObject bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);   // 爆弾を生成

                    Rigidbody rb = bomb.GetComponent<Rigidbody>();
                    rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

                    bombCount--;   // 爆弾を一個消費
                }
                else
                {
                    GameObject snowball = Instantiate(snowballPrefab, transform.position, Quaternion.identity);   // 雪玉を生成

                    Rigidbody rb = snowball.GetComponent<Rigidbody>();
                    rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

                    snowballCount--;   // 雪玉を一個消費
                }
            }
        }
    }

    public void SwitchWeapon()   // 武器の切り替え処理
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) useBomb = !useBomb;
    }
}
