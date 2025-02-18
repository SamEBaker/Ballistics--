using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float myTimeScale = 0.5f;
    public GameObject target;
    public float launchForce = 10f;
    public GameObject bullet;
    public GameObject barrel;

    void Start()
    {
        Vector3 startPos = transform.position;
        Time.timeScale = myTimeScale; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("PEW");
            FiringSolutions fs = new FiringSolutions();
            Nullable<Vector3> aimVector = fs.Calc(transform.position, target.transform.position, launchForce, Physics.gravity);
            if (aimVector.HasValue)
            {
                //rb.AddForce(aimVector.Value.normalized * launchForce, ForceMode.VelocityChange);
                GameObject b = Instantiate(bullet);
                //b.transform.position = barrel.transform.position;
                Rigidbody rb = b.GetComponent<Rigidbody>();
                rb.AddForce(aimVector.Value.normalized * launchForce, ForceMode.VelocityChange);

            }
        }
    }
}
