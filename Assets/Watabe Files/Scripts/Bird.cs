using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bird : MonoBehaviour
{
    [Header("前進速度"), SerializeField]
    private float speed = 1;

    // 円の半径を設定します。
    public float radius = 10f;

    private Transform player;

    private GameManager gameManager;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        gameManager = FindAnyObjectByType<GameManager>();
    }

    void Update()
    {
        //CalcPosition();
        Coming();
    }

    void Coming()
    {
        if(!gameManager.IsGameclear && !gameManager.IsGameover)
        {
            transform.LookAt(player.position);

            transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }

    void CalcPosition()
    {
        float phase = Time.time * 1 * Mathf.PI + transform.position.y;

        float yPos = radius * Mathf.Sin(phase / 5);

        gameObject.transform.position = new Vector3(transform.position.x, yPos + 35, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
