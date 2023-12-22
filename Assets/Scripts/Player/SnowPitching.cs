using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowPitching : MonoBehaviour
{
    [Header("飛ばす雪玉のプレファブ")]
    public GameObject snowballPrefab;

    [Header("飛ばす爆弾のプレファブ")]
    public GameObject bomb;

    [Header("飛ばす雪玉の勢い"), SerializeField]
    public float throwForce = 10.0f;

    public int bombCount = 10;        // 爆弾残弾数
    public int snowballCount = 30;   // 雪玉残弾数

    [Header("爆弾選択中の表示"), SerializeField]
    private GameObject bombCursor;

    [Header("雪玉選択中の表示"), SerializeField]
    private GameObject snowballCursor;

    private bool useBomb = false;   // 爆弾を使うか

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
                    GameObject _bomb = Instantiate(bomb, transform.position, Quaternion.identity);   // 雪玉を生成

                    Rigidbody rb = _bomb.GetComponent<Rigidbody>();
                    rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

                    bombCount--;   // 雪玉を一個消費
                }
            }
            else
            {
                if (snowballCount > 0)   // 雪玉が残っている場合
                {
                    GameObject snowball = Instantiate(snowballPrefab, transform.position, Quaternion.identity);   // 雪玉を生成

                    Rigidbody rb = snowball.GetComponent<Rigidbody>();
                    rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

                    snowballCount--;   // 雪玉を一個消費
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
