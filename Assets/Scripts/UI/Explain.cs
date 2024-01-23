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
        audioSource.PlayOneShot(openSE);//SE�Đ�

        if (explainPanel != null)
        {
            menubutton.SetActive(false);
            explainPanel.SetActive(true);   // ������@�\��
            Time.timeScale = 0;   // ���Ԓ�~
        }
        else
        {
            menubutton.SetActive(true);
        }
    }

    public void QuitExplain()   // ������@��ʂ���鏈���i�{�^���Ɋ��蓖�āj
    {
        audioSource.PlayOneShot(closeSE);//SE�Đ�
        explainPanel.SetActive(false);   // ������@��\��
        menubutton.SetActive(true);
        Time.timeScale = 1;   // ���Ԃ����ɖ߂�

        cursorChanger.ChangeCursorVisible(false);   // �J�[�\���̐؂�ւ�
    }


    //���j���[
    public void OpenMenu()
    {
        //if (explainPanel == null) return;

        audioSource.PlayOneShot(openSE);//SE�Đ�
        menubutton.SetActive(false);
        menuPanel.SetActive(true);
        cursorChanger.ChangeCursorVisible(true);

        Time.timeScale = 0;
        print("�Ƃ܂�");
    }

    public void QuitMenu()   // ������@��ʂ���鏈���i�{�^���Ɋ��蓖�āj
    {
        audioSource.PlayOneShot(closeSE);//SE�Đ�
        menubutton.SetActive(true);   // ������@��\��
        menuPanel.SetActive(false);
        cursorChanger.ChangeCursorVisible(false);

        Time.timeScale = 1;   // ���Ԃ����ɖ߂�
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
