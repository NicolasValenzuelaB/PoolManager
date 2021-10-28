using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float lifeTime = 3.0f;
    void Update()
    {
        if (lifeTime < 0.0f)
        {
            PoolManager.sharedInstance.ReturnObjToPool(this.gameObject);
            lifeTime = 3.0f;
        }
        lifeTime -= Time.deltaTime;
    }
}
