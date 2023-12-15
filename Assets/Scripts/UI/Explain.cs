using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explain : MonoBehaviour
{
    [Header("������@�\���I�u�W�F�N�g"), SerializeField]
    private GameObject explainPanel;

    [Header("���j���[�I�u�W�F�N�g"), SerializeField]
    private GameObject menuPanel;

    [Header("���j���[�{�^���I�u�W�F�N�g"), SerializeField]
    private GameObject menubutton;

    [Header("�Q�[���ɖ߂�{�^��"), SerializeField]
    private GameObject returnButton;

    // Start is called before the first frame update
    void Start()
    {
        explainPanel.SetActive(true);   // ������@�\��
        menubutton.SetActive(false);
        menuPanel.SetActive(false);
        Time.timeScale = 0;   // ���Ԓ�~  
    }

    public void QuitExplain()   // ������@��ʂ���鏈���i�{�^���Ɋ��蓖�āj
    {
        explainPanel.SetActive(false);   // ������@��\��
        menubutton.SetActive(true);
        Time.timeScale = 1;   // ���Ԃ����ɖ߂�
    }


    //���j���[
    public void OpenMenu()
    {
        menubutton.SetActive(false);
        menuPanel.SetActive(true);

        Time.timeScale = 0;
    }

    public void QuitMenu()   // ������@��ʂ���鏈���i�{�^���Ɋ��蓖�āj
    {
        menubutton.SetActive(true);   // ������@��\��
        menuPanel.SetActive(false);
        Time.timeScale = 1;   // ���Ԃ����ɖ߂�
    }

    public void ReturnGame() 
    {
        SceneManager.LoadScene("Game");
    }
}
