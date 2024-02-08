using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [Header("ì«Ç›çûÇﬁÉVÅ[ÉìÇÃñºëO"), SerializeField]
    private string sceneName;

    public void OnClick()
    {
        SceneManager.LoadScene(sceneName);
    }
   
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
