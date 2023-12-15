using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("�z���G���A�̃I�u�W�F�N�g"), SerializeField]
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
                    vacuumArea.SetActive(true);   // �z���G���A��L����
                }
                else
                {
                    vacuumArea.SetActive(false);   // �z���G���A�𖳌���
                }

                if (Input.GetMouseButtonDown(0))
                {
                    snowPitch.ThrowSnowball();   // ��ʂ𓊂���
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if(!gameManager.IsGameover && !gameManager.IsGameclear) 
        {
            playerMove.MoveHorizontal();   // ���ړ�
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!gameManager.IsGameclear && !gameManager.IsGameover)
        {
            if (collision.gameObject.CompareTag("SnowMan"))
            {
                gameManager.Dead();   // �Q�[���I�[�o�[����
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SnowBall Obj"))
        {
            Destroy(other.gameObject);
            snowPitch.ammoCount += 10;   // ��ʂ̕�[
        }
    }
}
