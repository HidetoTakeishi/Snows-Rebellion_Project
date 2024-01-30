using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("zøGAÌIuWFNg"), SerializeField]
    private GameObject vacuumArea;
    [Header("áÊðz¢ñ¾ÌSE"), SerializeField]
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
                    vacuumArea.SetActive(true);   // zøGAðLø»
                }
                else
                {
                    vacuumArea.SetActive(false);   // zøGAð³ø»
                }

                if (Input.GetMouseButtonDown(0))
                {
                    snowPitch.ThrowSnowball();   // áÊð°é
                    audioSource.PlayOneShot(DestoroySE);//SEÄ¶
                }

                snowPitch.SwitchWeapon();
            }
        }

        if(lifeControl.Life <= 0 && deadTrigger)
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
                //gameManager.Dead();   // Q[I[o[
            }
        }

        if (collision.gameObject.CompareTag("SnowBall Obj"))
        {
            Destroy(collision.gameObject);
            snowPitch.snowballCount += 2;   // áÊÌâ[
            SESource.instance.PlaySE(vacuumSE);
        }
        if(collision.gameObject.CompareTag("Bomb Obj"))
        {
            Destroy(collision.gameObject);
            snowPitch.bombCount++;   // eÌâ[
            SESource.instance.PlaySE(vacuumSE);
        }
    }
}
