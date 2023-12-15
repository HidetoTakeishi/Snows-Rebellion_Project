using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnowballDisplay : MonoBehaviour
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
        ammoCounter.text = "雪玉 : " + snowPitching.snowballCount;   // 残弾数の表示／更新
    }
}
