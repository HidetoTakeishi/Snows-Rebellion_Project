using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    [Header("è∆èÄÇÃâÊëú"), SerializeField]
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
        sightImg.transform.position = Input.mousePosition;   // É}ÉEÉXÇ…í«è]Ç≥ÇπÇÈ
    }

    public void ChangeCursorVisible(bool isActive)
    {
        Cursor.visible = isActive;

        sightImg.SetActive(!Cursor.visible);
    }
}
