using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public int poolSize;
    public static PoolManager sharedInstance;
    [SerializeField] public List<GameObject> listPrefab;
    [SerializeField] public List<GameObject> listPrefabClone;
    public List<GameObject> cube;
    public List<GameObject> cube2;
    public int contadorCube= 0;
    public int contadorCube2 = 0;
    [SerializeField]
    private Dictionary<string, int> users;

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
        {   // objectList : []
            for (int listPrefabItem = 0; listPrefabItem < listPrefab.Count; listPrefabItem++)
            {
                GameObject newObj = Instantiate(listPrefab[listPrefabItem]);
                listPrefabClone.Add(newObj);
                newObj.SetActive(false);
                //objectList.Add(newObj)

            }
            // dict : {cube2: [objectList] }
        }
        /*string cadena = listPrefab[0].ToString();
        char delimitador = '(';
        string[] valores = cadena.Split(delimitador);
        print("Valores " + valores[0]);
        print(listPrefabClone[0]);
        print(listPrefab[0]);*/
        //cube = listPrefabClone.FindAll(e => e.name == "Cube(Clone)");
        //cube2 = listPrefabClone.FindAll(e => e.name == "Cube2(Clone)");
    }

    public GameObject GetObjectFromPool(Vector3 newPosition, Quaternion newRotation, string num)
    {


        if (num == "1")
        {
            cube = listPrefabClone.FindAll(e => e.name == "Cube(Clone)");
            //int contador1 = int.Parse(contador);
            if(contadorCube <= cube.Count - 1)
            {
                cube[contadorCube].SetActive(true);
                contadorCube++;
                return cube[contadorCube - 1];
            }
            else if (contadorCube > cube.Count - 1)
            {
                contadorCube = 0;
                cube[contadorCube].SetActive(true);
                contadorCube++;
                return cube[contadorCube - 1];
            }

            /*if (contadorCube <= cube.Count - 1)
            {
                cube[contadorCube].SetActive(true);
                contadorCube++;
                return cube[contadorCube - 1];
            }
            else if (contadorCube > cube.Count - 1)
            {
                contadorCube = 0;
                cube[contadorCube].SetActive(true);
                contadorCube++;
                return cube[contadorCube - 1];
            }*/



        }
        else if (num == "2")
        {
            cube = listPrefabClone.FindAll(e => e.name == "Cube2(Clone)");

            if (contadorCube2 <= cube.Count -1)
            {
                cube[contadorCube2].SetActive(true);
                contadorCube2++;
                return cube[contadorCube2-1];
                
            }
            else if(contadorCube2 > cube.Count-1)
            {
                contadorCube2 = 0;
                cube[contadorCube2].SetActive(true);
                contadorCube2++;
                return cube[contadorCube2-1];
            }

        }
        return null;
    }

    public void ReturnObjToPool(GameObject go)
    {
        go.SetActive(false);

    }
}
