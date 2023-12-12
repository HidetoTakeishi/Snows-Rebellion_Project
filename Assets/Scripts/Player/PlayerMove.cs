using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("横方向の移動速度"), SerializeField]
    private float xSpeed = 0;

    [Header("横方向の移動制限"), SerializeField]
    private float xMoveLimit = 1;

    // Start is called before the first frame update
    void Start()
    {
        // 値の調整
        if (xSpeed <= 0) xSpeed = 1;
        if (xMoveLimit <= 0) xMoveLimit = 1;
    }

    public void MoveHorizontal()   // 左右移動を行う処理
    {
        float moveX = Input.GetAxis("Horizontal") * xSpeed;   // A Dキーの入力で左右移動
        transform.position += new Vector3(moveX, 0, 0) * Time.deltaTime;   // 移動量を加える

        Vector3 playerPos = transform.position;
        playerPos.x = Mathf.Clamp(playerPos.x, -xMoveLimit, xMoveLimit);   // X座標を制限
        transform.position = playerPos;   // 制限した座標を適用
    }
}
