using System.Collections;
using System.Collections.Generic;
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

    private void Awake()
    {
        sphereCollider = sphereCollider.GetComponent<SphereCollider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // 値の調整
        if(explodeDelay <= 0) explodeDelay = 1;

        sphereCollider.enabled = false;
        Invoke("Begine", explodeDelay);
    }

    // Update is called once per frame
    void Update()
    {
        Explode();
    }

    private void Begine()   // 起爆処理
    {
        sphereCollider.enabled = true;

        if (explodeEffect != null) Instantiate(explodeEffect, transform.position, Quaternion.identity);   // 爆発エフェクト生成
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
                Destroy(this.gameObject);
            }
        }
    }
}
