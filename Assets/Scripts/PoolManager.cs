using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public int poolSize;
    public static PoolManager sharedInstance;
    [SerializeField] public List<GameObject> lista;
    [SerializeField] public List<GameObject> lista2;
    public List<GameObject> cube;
    public List<GameObject> cube2;
    public int contadorCube= 0;
    public int contadorCube2 = 0;

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

        for (int i = 0; i < poolSize; i++)
        {

            GameObject newObj = Instantiate(lista[0]);
            GameObject newObj2 = Instantiate(lista[1]);
            lista2.Add(newObj);
            lista2.Add(newObj2);
            newObj.SetActive(false);
            newObj2.SetActive(false);
            cube = lista2.FindAll(e => e.name == "Cube(Clone)");
            cube2 = lista2.FindAll(e => e.name == "Cube2(Clone)");
        }
    }

    public GameObject GetObjectFromPool(Vector3 newPosition, Quaternion newRotation, string num)
    {
        if (num == "1")
        {
            
            if (contadorCube<=cube.Count -1)
            {
                cube[contadorCube].SetActive(true);
                contadorCube++;
                return cube[contadorCube-1];
            }
            else if (contadorCube > cube.Count-1)
            {
                contadorCube = 0;
                cube[contadorCube].SetActive(true);
                contadorCube++;
                return cube[contadorCube-1];
            }

            

        }
        else if (num == "2")
        {
            
            if (contadorCube2 <= cube2.Count -1)
            {
                cube2[contadorCube2].SetActive(true);
                contadorCube2++;
                return cube2[contadorCube2-1];
                
            }
            else if(contadorCube2 > cube2.Count-1)
            {
                contadorCube2 = 0;
                cube2[contadorCube2].SetActive(true);
                contadorCube2++;
                return cube2[contadorCube2-1];
            }

        }
        return null;
    }

    public void ReturnObjToPool(GameObject go)
    {
        go.SetActive(false);

    }
}
