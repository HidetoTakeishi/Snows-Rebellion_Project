using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombDisplay : MonoBehaviour
{
    private Text bombCounter;
    private SnowPitching snowPitching;

    // Start is called before the first frame update
    void Start()
    {
        bombCounter = GetComponent<Text>();
        snowPitching = FindAnyObjectByType<SnowPitching>();
    }

    // Update is called once per frame
    void Update()
    {
        bombCounter.text = "îöíe : " + snowPitching.bombCount;   // écíeêîÇÃï\é¶Å^çXêV
    }
}
