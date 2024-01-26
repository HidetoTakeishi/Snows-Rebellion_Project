using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SESource : MonoBehaviour
{
    public static SESource instance;

    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            //Debug.Log("�ݒu���܂���");
        }
        else
        {
            Destroy(gameObject);
            //Debug.Log("�j�󂵂܂���");
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySE(AudioClip clip)
    {
        if (clip == null) return;

        audioSource.PlayOneShot(clip);
    }
}
