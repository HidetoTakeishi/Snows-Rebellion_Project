using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [Header("“Ç‚İ‚ŞƒV[ƒ“‚Ì–¼‘O"), SerializeField]
    private string sceneName;

    public void OnClick()
    {
        if (sceneName == null) return;
        SceneManager.LoadScene(sceneName);
    }
}
