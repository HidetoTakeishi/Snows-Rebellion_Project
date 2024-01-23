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
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        sightImg.transform.position = Input.mousePosition;
    }
}
