using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [Header("投げてから起爆までにかかる時間"), SerializeField]
    private float explodeDelay = 1;

    [Header("爆破範囲"), SerializeField]
    private float explodeRange = 1;

    [Header("爆発の当たり判定となるオブジェクト"), SerializeField]
    private SphereCollider sphereCollider;

    [Header("爆発エフェクト"), SerializeField]
    private GameObject explodeEffect;

    [Header("爆発SE"), SerializeField]
    private AudioClip explodeSE;

    private IEnumerator explodeCoru = null;

    private bool isExplode = false;   // 爆発したかどうか

    private AudioSource audioSource;

    private void Awake()
    {
        sphereCollider = sphereCollider.GetComponent<SphereCollider>();
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // 値の調整
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
            GetComponent<MeshRenderer>().enabled = false;   // 爆弾を消す（見た目だけ）
            sphereCollider.enabled = true;

            if (explodeEffect != null)
            {
                GameObject _explode = Instantiate(explodeEffect, transform.position, Quaternion.identity);   // 爆発エフェクト生成
                _explode.transform.localScale *= explodeRange / 2.5f;   // エフェクトのサイズ調整
            }
            audioSource.PlayOneShot(explodeSE);   // 爆発SE再生
        }

        yield return new WaitForSeconds(5);

        Destroy(this.gameObject);
    }

    private void Explode()   // 爆破範囲の更新処理
    {
        if (sphereCollider.enabled)
        {
            if (sphereCollider.radius <= explodeRange)
            {
                sphereCollider.radius += 500 * Time.deltaTime;
            }
            else
            {
                sphereCollider.enabled = false;   // コライダーを無効化
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
