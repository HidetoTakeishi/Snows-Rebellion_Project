using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    [Header("照準の画像"), SerializeField]
    private GameObject sightImg;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;

        sightImg.SetActive(!Cursor.visible);
    }

    // Update is called once per frame
    void Update()
    {
        sightImg.transform.position = Input.mousePosition;   // マウスに追従させる
    }

    public void ChangeCursorVisible(bool isActive)
    {
        Cursor.visible = isActive;

        sightImg.SetActive(!Cursor.visible);
    }
}
