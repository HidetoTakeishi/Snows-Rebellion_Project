using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bird : MonoBehaviour
{
    // 円の半径を設定します。
    public float radius = 10f;

    // 初期位置を取得し、高さを保持します。
    Vector3 initPos;

    void Start()
    {
        // 初期位置を保持します。
        //initPos = gameObject.transform.position;
    }

    void Update()
    {
        CalcPosition();
    }

    void CalcPosition()
    {
        // 位相を計算します。
        float phase = Time.time * 1 * Mathf.PI;

        // 現在の位置を計算します。
        //float xPos = radius * Mathf.Cos(phase);
        float yPos = radius * Mathf.Sin(phase);

        // ゲームオブジェクトの位置を設定します。
        //Vector3 pos = new Vector3(initPos.x, yPos, initPos.z);
        gameObject.transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }
}
