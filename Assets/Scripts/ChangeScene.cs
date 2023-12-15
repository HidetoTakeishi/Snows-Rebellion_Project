using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [Header("読み込むシーンの名前"), SerializeField]
    private string sceneName;

    public void OnClick()
    {
        if (sceneName == null) return;
        SceneManager.LoadScene(sceneName);
    }
}
