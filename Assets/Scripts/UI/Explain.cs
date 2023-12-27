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
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        explainPanel.SetActive(true);   // 操作方法表示
        menubutton.SetActive(false);
        menuPanel.SetActive(false);
        Time.timeScale = 0;   // 時間停止  

        audioSource = GetComponent<AudioSource>();
    }

    public void QuitExplain()   // 操作方法画面を閉じる処理（ボタンに割り当て）
    {
        explainPanel.SetActive(false);   // 操作方法非表示
        menubutton.SetActive(true);
        Time.timeScale = 1;   // 時間を元に戻す
    }


    //メニュー
    public void OpenMenu()
    {
        menubutton.SetActive(false);
        menuPanel.SetActive(true);

        Time.timeScale = 0;
        print("とまる");
    }

    public void QuitMenu()   // 操作方法画面を閉じる処理（ボタンに割り当て）
    {
        audioSource.PlayOneShot(closeSE);//SE再生
        menubutton.SetActive(true);   // 操作方法非表示
        menuPanel.SetActive(false);
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
