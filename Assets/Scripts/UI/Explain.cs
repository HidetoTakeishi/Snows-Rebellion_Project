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
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        explainPanel.SetActive(true);   // ������@�\��
        menubutton.SetActive(false);
        menuPanel.SetActive(false);
        Time.timeScale = 0;   // ���Ԓ�~  

        audioSource = GetComponent<AudioSource>();
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
        print("�Ƃ܂�");
    }

    public void QuitMenu()   // ������@��ʂ���鏈���i�{�^���Ɋ��蓖�āj
    {
        audioSource.PlayOneShot(closeSE);//SE�Đ�
        menubutton.SetActive(true);   // ������@��\��
        menuPanel.SetActive(false);
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
