using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explain : MonoBehaviour
{
    [Header("操作方法表示オブジェクト"), SerializeField]
    private GameObject explainPanel;

    // Start is called before the first frame update
    void Start()
    {
        explainPanel.SetActive(true);   // 操作方法表示

        Time.timeScale = 0;   // 時間停止
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitExplain()   // 操作方法画面を閉じる処理
    {
        explainPanel.SetActive(false);   // 操作方法非表示

        Time.timeScale = 1;   // 時間を元に戻す
    }
}
