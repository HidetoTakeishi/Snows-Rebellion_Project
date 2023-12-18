using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillcountDisplay : MonoBehaviour
{
    private Text killCountText;

    void Start()
    {
        killCountText = GetComponent<Text>();
    }

    public void DispKillcount(int _killCount)
    {
        if (killCountText == null) return;

        killCountText.text = "åÇîjêî : " + _killCount;
    }
}
