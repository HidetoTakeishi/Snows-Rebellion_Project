using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCountDisplay : MonoBehaviour
{
    private Text killCounter;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        killCounter = GetComponent<Text>();
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        killCounter.text = "åÇîjêî : " + gameManager.killCount + " / " + gameManager.ClearConditions;
    }
}
