using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeControl : MonoBehaviour
{
    [Header("プレイヤーライフ"), SerializeField]
    private int lifePoint = 3;
    public GameObject DamageImage;

    public void Damage()
    {
        lifePoint--;
        print(lifePoint);
        DamageImage.gameObject.SetActive(true);
        Invoke("DamageTime", 0.05f);
    }

    public void DamageTime()
    {
        DamageImage.gameObject.SetActive(false);
    }

    public int Life
    {
        get { return lifePoint; }
    }
}
