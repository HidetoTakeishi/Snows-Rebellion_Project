using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeControl : MonoBehaviour
{
    [Header("�v���C���[���C�t"), SerializeField]
    private int lifePoint = 3;

    public void Damage()
    {
        lifePoint--;
        print(lifePoint);
    }

    public int Life
    {
        get { return lifePoint; }
    }
}
