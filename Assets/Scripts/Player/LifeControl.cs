using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeControl : MonoBehaviour
{
    [Header("プレイヤーライフ"), SerializeField]
    private int lifePoint = 3;
    private Image DamageImage;

    public void Damage()
    {
        lifePoint--;
        print(lifePoint);
        DamageImage.gameObject.SetActive(false);
        Invoke("DamageImage", 0.1f);
    }

    public int Life
    {
        get { return lifePoint; }
    }
}
