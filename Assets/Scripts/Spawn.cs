using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject cubePrefab;
    public float cubeForce = 3.0f;
    public int contador = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            string contador1 = contador.ToString() ;
            GameObject cube = PoolManager.sharedInstance.GetObjectFromPool(spawnPoint.position, spawnPoint.rotation, "1");
            //Contador();
            Rigidbody rb = cube.GetComponent<Rigidbody>();
            rb.AddForce(spawnPoint.up * cubeForce, ForceMode.Impulse);
        } 

    }
    /*public int Contador()
    {
        print("Contador " + contador);
        return contador++;
    }*/

}
