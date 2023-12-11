using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowPitching : MonoBehaviour
{
    public GameManager GameManager;
    public GameObject snowballPrefab;

    public Transform throwPoint;

    [Header("îÚÇŒÇ∑ê·ã ÇÃê®Ç¢"), SerializeField]
    public float throwForce = 10.0f;

    public float ammoCount = 30;   // écíeêî

    private bool canThrow = true;

    private void Update()
    {
        if(Time.timeScale != 0)
        {
            if (canThrow && Input.GetMouseButtonDown(0))
            {
                ThrowSnowball();
            }
        }
    }

    void ThrowSnowball()
    {
        Camera mainCamera = Camera.main;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if(ammoCount > 0)   // ê·ã Ç™écÇ¡ÇƒÇ¢ÇÈèÍçá
        {
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Vector3 throwDirection = (hitInfo.point - transform.position).normalized;

                GameObject snowball = Instantiate(snowballPrefab, transform.position, Quaternion.identity);

                Rigidbody rb = snowball.GetComponent<Rigidbody>();
                rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

                ammoCount--;   // ê·ã ÇàÍå¬è¡îÔ
            }
        }
    }

    //public void DisableThrowing()
    //{
    //    canThrow = false;
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SnowMan"))
        {
            GameManager.Dead();
            canThrow = false;
        }
    }
}
