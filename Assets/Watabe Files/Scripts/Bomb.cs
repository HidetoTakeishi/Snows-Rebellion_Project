using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [Header("�����Ă���N���܂łɂ����鎞��"), SerializeField]
    private float explodeDelay = 1;

    [Header("���j�͈�"), SerializeField]
    private float explodeRange = 1;

    [Header("�����̓����蔻��ƂȂ�I�u�W�F�N�g"), SerializeField]
    private SphereCollider sphereCollider;

    [Header("�����G�t�F�N�g"), SerializeField]
    private GameObject explodeEffect;

    private void Awake()
    {
        sphereCollider = sphereCollider.GetComponent<SphereCollider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // �l�̒���
        if(explodeDelay <= 0) explodeDelay = 1;

        sphereCollider.enabled = false;
        Invoke("Begine", explodeDelay);
    }

    // Update is called once per frame
    void Update()
    {
        Explode();
    }

    private void Begine()   // �N������
    {
        sphereCollider.enabled = true;

        if (explodeEffect != null) Instantiate(explodeEffect, transform.position, Quaternion.identity);   // �����G�t�F�N�g����
    }

    private void Explode()   // ���j�͈͂̍X�V����
    {
        if (sphereCollider.enabled)
        {
            if (sphereCollider.radius <= explodeRange)
            {
                sphereCollider.radius += 500 * Time.deltaTime;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
