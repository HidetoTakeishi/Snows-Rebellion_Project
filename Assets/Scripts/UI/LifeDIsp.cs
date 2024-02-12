using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeDIsp : MonoBehaviour
{
    [Header("ライフのオブジェクト"), SerializeField]
    private Image[] lifes;
    [Header("ライフを失ったときの画像"), SerializeField]
    private Sprite lifeLostImg;

    private LifeControl lifeControl;

    // Start is called before the first frame update
    void Start()
    {
        lifeControl = FindAnyObjectByType<LifeControl>();

        for (int i = 0; i < lifes.Length; i++)
        {
            lifes[i] = lifes[i].GetComponent<Image>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeControl.Life == 2)
        {
            lifes[2].sprite = lifeLostImg;
        }
        else if(lifeControl.Life == 1)
        {
            lifes[2].sprite = lifeLostImg;
            lifes[1].sprite = lifeLostImg;
        }
        else if(lifeControl.Life == 0)
        {
            lifes[2].sprite = lifeLostImg;
            lifes[1].sprite = lifeLostImg;
            lifes[0].sprite = lifeLostImg;
        }
    }
}
