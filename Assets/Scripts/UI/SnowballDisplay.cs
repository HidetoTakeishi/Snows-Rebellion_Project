using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnowballDisplay : MonoBehaviour
{
    private Text ammoCounter;
    private GameObject bombCursor;

    // Start is called before the first frame update
    void Start()
    {
        ammoCounter = GetComponent<Text>();

        bombCursor = transform.GetChild(0).gameObject;
    }

    public void DispSnowball(int _snowball, bool _trigger)
    {
        ammoCounter.text = "ê·ã  : " + _snowball;

        bombCursor.SetActive(_trigger);
    }
}
