using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("吸引エリアのオブジェクト"), SerializeField]
    private GameObject vacuumArea;

    private GameManager gameManager;
    private SnowPitching snowPitch;
    private PlayerMove playerMove;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        snowPitch = GetComponent<SnowPitching>();
        playerMove = GetComponent<PlayerMove>();
    }

    // Start is called before the first frame update
    void Start()
    {
        vacuumArea.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale != 0)
        {
            if(!gameManager.IsGameover && !gameManager.IsGameclear)
            {
                if (Input.GetMouseButton(1))
                {
                    vacuumArea.SetActive(true);   // 吸引エリアを有効化
                }
                else
                {
                    vacuumArea.SetActive(false);   // 吸引エリアを無効化
                }

                if (Input.GetMouseButtonDown(0))
                {
                    snowPitch.ThrowSnowball();   // 雪玉を投げる
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if(!gameManager.IsGameover && !gameManager.IsGameclear) 
        {
            playerMove.MoveHorizontal();   // 横移動
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!gameManager.IsGameclear && !gameManager.IsGameover)
        {
            if (collision.gameObject.CompareTag("SnowMan"))
            {
                gameManager.Dead();   // ゲームオーバー処理
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SnowBall Obj"))
        {
            Destroy(other.gameObject);
            snowPitch.ammoCount += 10;   // 雪玉の補充
        }
    }
}
