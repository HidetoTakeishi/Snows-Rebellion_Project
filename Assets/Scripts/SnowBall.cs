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
            // �n�ʂɓ��������ꍇ�A�ʂ�����
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("SnowMan"))
        {
            Destroy(gameObject);
            gameManager.killCount++;   // ���j���̃J�E���g
        }
    }
}
