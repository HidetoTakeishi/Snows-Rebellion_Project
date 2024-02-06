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

    private float height;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        //CalcPosition();
        Coming();
    }

    void Coming()
    {
        transform.LookAt(player.position);
        
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    void CalcPosition()
    {
        float phase = Time.time * 1 * Mathf.PI;

        float yPos = radius * Mathf.Sin(phase);

        gameObject.transform.position = new Vector3(transform.position.x, yPos + 35, transform.position.z);
    }
}
