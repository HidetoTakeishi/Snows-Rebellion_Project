using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [Header("���x"), SerializeField]
    private float moveSpeed;

    private Transform player;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();

        // �v���C���[�I�u�W�F�N�g���^�O���猟�����Ď擾
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
            // �v���C���[�̈ʒu������
            transform.LookAt(player);

            // �v���C���[�Ɍ������Ĉړ�
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // �v���C���[�ɓ��������ꍇ�A�G������
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("SnowBall"))
        {
            // ��ʂɓ��������ꍇ�A�G������
            Destroy(gameObject);
        }
    }
}
