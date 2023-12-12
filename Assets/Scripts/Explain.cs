using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explain : MonoBehaviour
{
    [Header("操作方法表示オブジェクト"), SerializeField]
    private GameObject explainPanel;

    [Header("操作方法を表示中に消すオブジェクト"), SerializeField]
    private GameObject undispObj;

    // Start is called before the first frame update
    void Start()
    {
        explainPanel.SetActive(true);   // 操作方法表示
        undispObj.SetActive(false);
        Time.timeScale = 0;   // 時間停止  
    }

    public void QuitExplain()   // 操作方法画面を閉じる処理（ボタンに割り当て）
    {
        explainPanel.SetActive(false);   // 操作方法非表示
        undispObj.SetActive(true);
        Time.timeScale = 1;   // 時間を元に戻す
    }
}
