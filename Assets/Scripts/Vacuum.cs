using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum : MonoBehaviour
{
    [Header("吸い込む速度"), SerializeField]
    private float vacuumSpeed = 1;

    [Header("プレイヤーの座標"), SerializeField]
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("SnowBall Obj"))
        {
            Vector3 direction = (player.position - other.transform.position).normalized;   // ベクトルの計算をして正規化
            other.transform.position += direction * vacuumSpeed;   // 正規化したベクトルに吸引速度を掛け合わせて適用
        }
    }
}
