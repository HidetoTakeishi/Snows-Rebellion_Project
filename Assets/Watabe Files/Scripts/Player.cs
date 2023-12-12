using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("吸引エリアのオブジェクト"), SerializeField]
    private GameObject vacuumArea;

    private SnowPitching snowPitch;
    private PlayerMove playerMove;

    // Start is called before the first frame update
    void Start()
    {
        snowPitch = GetComponent<SnowPitching>();
        playerMove = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale != 0)
        {
            if (Input.GetMouseButton(1))
            {
                vacuumArea.SetActive(true);
            }
            else
            {
                vacuumArea.SetActive(false);
            }
        }
    }

    private void FixedUpdate()
    {
        playerMove.MoveVertical();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SnowBall Obj"))
        {
            Destroy(other.gameObject);
            snowPitch.ammoCount += 10;   // 雪玉の補充
        }
    }
}
