using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explain : MonoBehaviour
{
    [Header("操作方法表示オブジェクト"), SerializeField]
    private GameObject explainPanel;

    [Header("メニューオブジェクト"), SerializeField]
    private GameObject menuPanel;

    [Header("メニューボタンオブジェクト"), SerializeField]
    private GameObject menubutton;

    [Header("ゲームに戻るボタン"), SerializeField]
    private GameObject returnButton;

    public AudioClip closeSE;
    public AudioClip openSE;
    AudioSource audioSource;

    private CursorChanger cursorChanger;

    // Start is called before the first frame update
    void Start()
    {
        cursorChanger = FindAnyObjectByType<CursorChanger>();

        menuPanel.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(openSE);//SE再生

        if (explainPanel != null)
        {
            menubutton.SetActive(false);
            explainPanel.SetActive(true);   // 操作方法表示
            Time.timeScale = 0;   // 時間停止
        }
        else
        {
            menubutton.SetActive(true);
        }
    }

    public void QuitExplain()   // 操作方法画面を閉じる処理（ボタンに割り当て）
    {
        audioSource.PlayOneShot(closeSE);//SE再生
        explainPanel.SetActive(false);   // 操作方法非表示
        menubutton.SetActive(true);
        Time.timeScale = 1;   // 時間を元に戻す

        cursorChanger.ChangeCursorVisible(false);   // カーソルの切り替え
    }


    //メニュー
    public void OpenMenu()
    {
        //if (explainPanel == null) return;

        audioSource.PlayOneShot(openSE);//SE再生
        menubutton.SetActive(false);
        menuPanel.SetActive(true);
        cursorChanger.ChangeCursorVisible(true);

        Time.timeScale = 0;
        print("とまる");
    }

    public void QuitMenu()   // 操作方法画面を閉じる処理（ボタンに割り当て）
    {
        audioSource.PlayOneShot(closeSE);//SE再生
        menubutton.SetActive(true);   // 操作方法非表示
        menuPanel.SetActive(false);
        cursorChanger.ChangeCursorVisible(false);

        Time.timeScale = 1;   // 時間を元に戻す
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene("Game");
    }

    public void RestartTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
