using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maincharactor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform���擾
        Transform myTransform = this.transform;

        //���[���h���W����ɁA��]���擾
        Vector3 worldAngle = myTransform.eulerAngles;
        worldAngle.x = 10.0f; // ���[���h���W����ɁAx�������ɂ�����]��10�x�ɕύX
        worldAngle.y = 10.0f; // ���[���h���W����ɁAy�������ɂ�����]��10�x�ɕύX
        worldAngle.z = 10.0f; // ���[���h���W����ɁAz�������ɂ�����]��10�x�ɕύX
        myTransform.eulerAngles = worldAngle; // ��]�p�x��ݒ�
    }
}
