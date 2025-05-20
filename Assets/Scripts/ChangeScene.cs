using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [Header("ì«Ç›çûÇﬁÉVÅ[ÉìÇÃñºëO"), SerializeField]
    private string sceneName;

    public void OnClick(bool isActiveCursor)
    {
        SceneManager.LoadScene(sceneName);

        if (isActiveCursor)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
   
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
