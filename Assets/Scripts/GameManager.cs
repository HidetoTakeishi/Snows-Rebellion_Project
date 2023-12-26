using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverPanel;
    public Button restartButton;
    public Button MenuButton;

    [Header("�N���A���ɕ\������UI"), SerializeField]
    private GameObject[] clearUI;

    [Header("�N���A�ɕK�v�ȐႾ��܂̌��j��"), SerializeField]
    private int clearConditions;
    [HideInInspector]
    public int killCount = 0;   // �Ⴞ��܂̌��j��

    private bool isGameclear;   // �Q�[���N���A�ɂȂ�����
    private bool isGameover;    // �Q�[���I�[�o�[�ɂȂ�����

    // Start is called before the first frame update
    void Start()
    {
        GameOverPanel.SetActive(false);
        restartButton.gameObject.SetActive(false);

        for (int i = 0; i < clearUI.Length; i++)
        {
            clearUI[i].SetActive(false);
        }

        if(clearConditions <= 0) clearConditions = 1;

        isGameclear = false;
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(killCount >= clearConditions && !isGameover)   // �N���A������B��������
        {
            isGameclear = true;
            for (int i = 0; i < clearUI.Length; i++)
            {
                MenuButton.gameObject.SetActive(false);
                clearUI[i].SetActive(true);   // �N���AUI�̕\��
            }
        }

        // �G�f�B�^�[�p�`�[�g
#if UNITY_EDITOR
        if(Time.timeScale != 0)
        {
            if (Input.GetKey(KeyCode.RightShift))
            {
                Time.timeScale = 5;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
#endif
    }

    public void Dead()
    {
        GameOverPanel.SetActive(true);
        restartButton.gameObject.SetActive(true);
        MenuButton.gameObject.SetActive(false);
        isGameover = true;
    }

    public bool IsGameover   // �Q�[���I�[�o�[����̃Q�b�^�[
    {
        get { return isGameover; }
    }

    public bool IsGameclear   // �Q�[���N���A����̃Q�b�^�[
    {
        get { return isGameclear; }
    }

    public int ClearConditions   // �N���A�����̃Q�b�^�[
    {
        get { return clearConditions; }
    }
}