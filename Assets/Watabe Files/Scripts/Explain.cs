using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explain : MonoBehaviour
{
    [Header("������@�\���I�u�W�F�N�g"), SerializeField]
    private GameObject explainPanel;

    // Start is called before the first frame update
    void Start()
    {
        explainPanel.SetActive(true);   // ������@�\��

        Time.timeScale = 0;   // ���Ԓ�~
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitExplain()   // ������@��ʂ���鏈��
    {
        explainPanel.SetActive(false);   // ������@��\��

        Time.timeScale = 1;   // ���Ԃ����ɖ߂�
    }
}
