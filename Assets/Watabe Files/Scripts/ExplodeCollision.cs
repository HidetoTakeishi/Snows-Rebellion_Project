using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeCollision : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("SnowMan"))
        {
            Destroy(other.gameObject);
            gameManager.killCount++;
        }
    }
}
