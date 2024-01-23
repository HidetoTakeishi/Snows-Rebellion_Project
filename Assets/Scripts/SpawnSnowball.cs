using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSnowball : MonoBehaviour
{
    public GameObject SnowBall;

    // Start is called before the first frame update
    private void OnDestroy()
    {
        DropItem();
    }

    private void DropItem()
    {
        // アイテムを生成して敵の位置に配置する
        Instantiate(SnowBall, transform.position, Quaternion.identity);
    }
}
