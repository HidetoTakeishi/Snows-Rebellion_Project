using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverPanel;
    public Button restartButton;
    public Button MenuButton;

    [Header("クリア時に表示するUI"), SerializeField]
    private GameObject[] clearUI;

    [Header("クリアに必要な雪だるまの撃破数"), SerializeField]
    private int clearConditions;
    [HideInInspector]
    public int killCount = 0;   // 雪だるまの撃破数

    private bool isGameclear;   // ゲームクリアになったか
    private bool isGameover;    // ゲームオーバーになったか

    [Header("ゲームオーバー時のSE"), SerializeField]
    private AudioClip gameocerSE;

    [Header("ゲームクリア時のSE"), SerializeField]
    private AudioClip gameClearSE;

    private AudioSource audioSource;

    private CursorChanger cursorChanger;

    bool trigger = true;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        cursorChanger = GetComponent<CursorChanger>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameOverPanel.SetActive(false);
        restartButton.gameObject.SetActive(false);

        for (int i = 0; i < clearUI.Length; i++)
        {
            clearUI[i].SetActive(false);
        }

        if(clearConditions <= 0) clearConditions = 1;

        isGameclear = false;
        isGameover = false;

        cursorChanger.ChangeCursorVisible(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(killCount >= clearConditions && !isGameover)   // クリア条件を達成したら
        {
            if (trigger == true)
            {
                audioSource.PlayOneShot(gameClearSE);
                trigger = false;
            }
            isGameclear = true;
            for (int i = 0; i < clearUI.Length; i++)
            {
                MenuButton.gameObject.SetActive(false);
                clearUI[i].SetActive(true);   // クリアUIの表示
            }
        }

        // エディター用チート
#if UNITY_EDITOR
        if(Time.timeScale != 0)
        {
            if (Input.GetKey(KeyCode.RightShift))
            {
                Time.timeScale = 5;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
#endif
    }

    public void Dead()
    {
        GameOverPanel.SetActive(true);
        restartButton.gameObject.SetActive(true);
        MenuButton.gameObject.SetActive(false);
        isGameover = true;
        audioSource.PlayOneShot(gameocerSE);
    }

    public bool IsGameover   // ゲームオーバー判定のゲッター
    {
        get { return isGameover; }
    }

    public bool IsGameclear   // ゲームクリア判定のゲッター
    {
        get { return isGameclear; }
    }

    public int ClearConditions   // クリア条件のゲッター
    {
        get { return clearConditions; }
    }
}