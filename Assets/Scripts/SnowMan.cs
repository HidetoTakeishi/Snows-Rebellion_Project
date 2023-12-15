using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowMan�@: MonoBehaviour
{
    public float moveSpeed = 5.0f; // �G�̈ړ����x
    private Transform player; // �v���C���[��Transform�R���|�[�l���g

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // �v���C���[�I�u�W�F�N�g���^�O���猟�����Ď擾
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
