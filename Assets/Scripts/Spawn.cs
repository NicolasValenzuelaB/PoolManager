using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject cubePrefab;
    public float cubeForce = 3.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject cube = PoolManager.sharedInstance.GetObjectFromPool(spawnPoint.position, spawnPoint.rotation);
            Rigidbody rb = cube.GetComponent<Rigidbody>();
            rb.AddForce(spawnPoint.up * cubeForce, ForceMode.Impulse);
        } 

    }
    
}
