using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [Header("�ǂݍ��ރV�[���̖��O"), SerializeField]
    private string sceneName;

    public void OnClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}
