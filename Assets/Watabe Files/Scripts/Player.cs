using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("吸引エリアのオブジェクト"), SerializeField]
    private GameObject vacuumArea;
    [Header("雪玉を吸い込んだ時のSE"), SerializeField]
    private AudioClip vacuumSE;

    private bool deadTrigger = true;

    private AudioSource audioSource;
    private GameManager gameManager;
    private SnowPitching snowPitch;
    private LifeControl lifeControl;

    public AudioClip DestoroySE;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = FindAnyObjectByType<GameManager>();
        snowPitch = GetComponent<SnowPitching>();
        lifeControl = GetComponent<LifeControl>();
    }

    // Start is called before the first frame update
    void Start()
    {
        vacuumArea.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (!gameManager.IsGameover && !gameManager.IsGameclear)
            {
                if (Input.GetMouseButton(1))
                {
                    vacuumArea.SetActive(true);   // 吸引エリアを有効化

                }
                else
                {
                    vacuumArea.SetActive(false);   // 吸引エリアを無効化
                }

                if (Input.GetMouseButtonDown(0))
                {
                    snowPitch.ThrowSnowball();   // 雪玉を投げる
                    audioSource.PlayOneShot(DestoroySE);//SE再生
                }

                snowPitch.SwitchWeapon();
            }
        }

        if(lifeControl.GetLife() <= 0 && deadTrigger)
        {
            gameManager.Dead();
            deadTrigger = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!gameManager.IsGameclear && !gameManager.IsGameover)
        {
            if (collision.gameObject.CompareTag("SnowMan"))
            {
                lifeControl.Damage();
                //gameManager.Dead();   // ゲームオーバー処理
            }
        }

        if (collision.gameObject.CompareTag("SnowBall Obj"))
        {
            Destroy(collision.gameObject);
            snowPitch.snowballCount += 2;   // 雪玉の補充
            SESource.instance.PlaySE(vacuumSE);
        }
    }


}
