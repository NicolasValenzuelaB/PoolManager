using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //public GameObject objPrefab;
    public int poolSize;
    //public Queue<GameObject> objPool;
    public static PoolManager sharedInstance;
    [SerializeField]
    public List<GameObject> lista;

    [SerializeField]
    public List<GameObject> lista2;

    void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
        Debug.Log("obj : que pasa :" + lista);

        for (int i = 0; i < poolSize; i++)
        {

            GameObject newObj = Instantiate(lista[0]);
            GameObject newObj2 = Instantiate(lista[1]);
            lista2.Add(newObj);
            lista2.Add(newObj2);
            newObj.SetActive(false);
            newObj2.SetActive(false);


        }
    }

    public GameObject GetObjectFromPool(Vector3 newPosition, Quaternion newRotation)
    {
        
        for (int i = 0; i< lista2.Count; i++)
        {
            if (!lista2[i].activeInHierarchy )
            {
                return lista2[i];
            }
        }
        return null;
        /*GameObject newObj = lista();
        newObj.SetActive(true);
        newObj.transform.SetPositionAndRotation(newPosition, newRotation);
        return newObj;*/
    }

    public void ReturnObjToPool(GameObject go)
    {
        go.SetActive(false);
        lista.Add(go);
    }
}
