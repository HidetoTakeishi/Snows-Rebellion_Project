using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // �n�ʂɓ��������ꍇ�A�ʂ�����
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("SnowMan"))
        {
            Destroy(gameObject);
        }
    }
}
