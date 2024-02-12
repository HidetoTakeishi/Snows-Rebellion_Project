using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [Header("速度"), SerializeField]
    private float moveSpeed;

    private Transform player;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();

        // プレイヤーオブジェクトをタグから検索して取得
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (!gameManager.IsGameover && !gameManager.IsGameclear)
        {
            // プレイヤーの位置を向く
            transform.LookAt(player);

            // プレイヤーに向かって移動
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // プレイヤーに当たった場合、敵を消去
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("SnowBall"))
        {
            // 雪玉に当たった場合、敵を消去
            Destroy(gameObject);
        }
    }
}
