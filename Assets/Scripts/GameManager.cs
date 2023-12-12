using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverPanel;
    public Button restartButton;

    private bool isGameover;   // ゲームオーバーになったか

    // Start is called before the first frame update
    void Start()
    {
        GameOverPanel.SetActive(false);
        restartButton.gameObject.SetActive(false);

        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Dead()
    {
        GameOverPanel.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameover = true;
    }

    public bool IsGameover   // ゲームオーバー判定のゲッター
    {
        get { return isGameover; }
    }
}