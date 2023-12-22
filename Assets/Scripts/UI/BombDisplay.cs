using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombDisplay : MonoBehaviour
{
    private Text bombCounter;
    private GameObject bombCursor;

    // Start is called before the first frame update
    void Start()
    {
        bombCounter = GetComponent<Text>();
        bombCursor = transform.GetChild(0).gameObject;
    }

    public void DispBomb(int _bomb, bool _trigger)
    {
        bombCounter.text = "”š’e : " + _bomb;   // c’e”‚Ì•\¦^XV

        bombCursor.SetActive(_trigger);
    }
}
