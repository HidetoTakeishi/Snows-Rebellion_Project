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
        // �A�C�e���𐶐����ēG�̈ʒu�ɔz�u����
        Instantiate(SnowBall, transform.position, Quaternion.identity);
    }
}
