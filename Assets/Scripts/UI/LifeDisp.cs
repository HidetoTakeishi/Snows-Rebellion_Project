using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeDisp : MonoBehaviour
{
    [Header("ƒ‰ƒCƒt‚Ì‰æ‘œ"), SerializeField]
    private GameObject[] lifeImgs;

    private LifeControl lControl;

    // Start is called before the first frame update
    void Start()
    {
        lControl = FindAnyObjectByType<LifeControl>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (lControl.Life)
        {
            case 3:
                lifeImgs[0].SetActive(true);
                lifeImgs[1].SetActive(true);
                lifeImgs[2].SetActive(true);
                break;

            case 2:
                lifeImgs[0].SetActive(false);
                lifeImgs[1].SetActive(true);
                lifeImgs[2].SetActive(true);
                break;

            case 1:
                lifeImgs[0].SetActive(false);
                lifeImgs[1].SetActive(false);
                lifeImgs[2].SetActive(true);
                break;

            case 0:
                lifeImgs[0].SetActive(false);
                lifeImgs[1].SetActive(false);
                lifeImgs[2].SetActive(false);
                break;
        }
    }
}
