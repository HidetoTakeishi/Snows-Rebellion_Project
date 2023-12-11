using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
    private Text ammoCounter;
    private SnowPitching snowPitching;

    // Start is called before the first frame update
    void Start()
    {
        ammoCounter = GetComponent<Text>();
        snowPitching = FindAnyObjectByType<SnowPitching>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoCounter.text = "残弾数 : " + snowPitching.AmmoCount;   // 残弾数の更新
    }
}
