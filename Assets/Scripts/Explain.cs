using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explain : MonoBehaviour
{
    [Header("������@�\���I�u�W�F�N�g"), SerializeField]
    private GameObject explainPanel;

    [Header("������@��\�����ɏ����I�u�W�F�N�g"), SerializeField]
    private GameObject undispObj;

    // Start is called before the first frame update
    void Start()
    {
        explainPanel.SetActive(true);   // ������@�\��
        undispObj.SetActive(false);
        Time.timeScale = 0;   // ���Ԓ�~  
    }

    public void QuitExplain()   // ������@��ʂ���鏈���i�{�^���Ɋ��蓖�āj
    {
        explainPanel.SetActive(false);   // ������@��\��
        undispObj.SetActive(true);
        Time.timeScale = 1;   // ���Ԃ����ɖ߂�
    }
}
