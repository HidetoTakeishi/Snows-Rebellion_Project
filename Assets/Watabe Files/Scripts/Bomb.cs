using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    [Header("����SE"), SerializeField]
    private AudioClip explodeSE;

    private IEnumerator explodeCoru = null;

    private bool isExplode = false;   // �����������ǂ���

    private AudioSource audioSource;

    private void Awake()
    {
        sphereCollider = sphereCollider.GetComponent<SphereCollider>();
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // �l�̒���
        if (explodeDelay <= 0) explodeDelay = 1;
        if (explodeRange <= 0) explodeRange = 1;

        sphereCollider.enabled = false;
        //Invoke("Begine", explodeDelay);

        explodeCoru = Explosion(true);
        StartCoroutine(explodeCoru);
    }

    // Update is called once per frame
    void Update()
    {
        Explode();
    }

    private IEnumerator Explosion(bool isStart)
    {
        if(isStart)
        {
            sphereCollider.enabled = false;

            yield return new WaitForSeconds(explodeDelay);
        }

        if(!isExplode)
        {
            isExplode = true;
            GetComponent<MeshRenderer>().enabled = false;   // ���e�������i�����ڂ����j
            sphereCollider.enabled = true;

            if (explodeEffect != null)
            {
                GameObject _explode = Instantiate(explodeEffect, transform.position, Quaternion.identity);   // �����G�t�F�N�g����
                _explode.transform.localScale *= explodeRange / 2.5f;   // �G�t�F�N�g�̃T�C�Y����
            }
            audioSource.PlayOneShot(explodeSE);   // ����SE�Đ�
        }

        yield return new WaitForSeconds(5);

        Destroy(this.gameObject);
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
                sphereCollider.enabled = false;   // �R���C�_�[�𖳌���
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SnowMan") && !isExplode)
        {
            explodeCoru = null;
            explodeCoru = Explosion(false);
            StartCoroutine(explodeCoru);
        }
    }
}
