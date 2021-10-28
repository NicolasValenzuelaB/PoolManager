using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn2 : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject cubePrefab;
    public float cubeForce = 3.0f;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject cube = PoolManager.sharedInstance.GetObjectFromPool(spawnPoint.position, spawnPoint.rotation,"2");
            Rigidbody rb = cube.GetComponent<Rigidbody>();
            rb.AddForce(spawnPoint.up * cubeForce, ForceMode.Impulse);
        }


    }
}
