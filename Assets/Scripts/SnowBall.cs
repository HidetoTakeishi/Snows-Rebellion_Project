using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // 地面に当たった場合、玉を消去
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("SnowMan"))
        {
            Destroy(gameObject);
            gameManager.killCount++;   // 撃破数のカウント
        }
    }
}
