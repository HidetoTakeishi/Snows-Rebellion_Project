using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowMan　: MonoBehaviour
{
    public float moveSpeed = 5.0f; // 敵の移動速度
    private Transform player; // プレイヤーのTransformコンポーネント

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // プレイヤーオブジェクトをタグから検索して取得
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if(!gameManager.IsGameover && !gameManager.IsGameclear)
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
