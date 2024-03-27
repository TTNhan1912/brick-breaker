using System.Collections.Generic;
using UnityEngine;


public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    public List<GameObject> listBlockHit1 = new List<GameObject>();
    public List<GameObject> listBlockHit2 = new List<GameObject>();
    public List<GameObject> listBlockBlack = new List<GameObject>();

    private int sizePool = 10;

    [SerializeField] private GameObject block1;
    [SerializeField] private GameObject block2;
    [SerializeField] private GameObject blockBlack;

    public Transform parent;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        for (int i = 0; i < sizePool; i++)
        {
            GameObject obj1 = Instantiate(block1);
            GameObject obj2 = Instantiate(block2);
            GameObject obj3 = Instantiate(blockBlack);

            obj1.transform.SetParent(parent);
            obj2.transform.SetParent(parent);
            obj3.transform.SetParent(parent);

            obj1.SetActive(false);
            obj2.SetActive(false);
            obj3.SetActive(false);

            listBlockHit1.Add(obj1);
            listBlockHit2.Add(obj2);
            listBlockBlack.Add(obj3);
        }
    }

    public GameObject GetBlock1()
    {
        for (int i = 0; i < listBlockHit1.Count; i++)
        {
            if (!listBlockHit1[i].activeInHierarchy)
            {
                return listBlockHit1[i];
            }
        }

        GameObject newObj = Instantiate(block1);
        newObj.transform.SetParent(parent);
        newObj.SetActive(false);
        listBlockHit1.Add(newObj);
        return newObj;

    }

    public GameObject GetBlock2()
    {
        for (int i = 0; i < listBlockHit2.Count; i++)
        {
            if (!listBlockHit2[i].activeInHierarchy)
            {
                return listBlockHit2[i];
            }
        }

        GameObject newObj = Instantiate(block2);
        newObj.transform.SetParent(parent);
        newObj.SetActive(false);
        listBlockHit2.Add(newObj);
        return newObj;
    }
    public GameObject GetBlockBlack()
    {
        for (int i = 0; i < listBlockBlack.Count; i++)
        {
            if (!listBlockBlack[i].activeInHierarchy)
            {
                return listBlockBlack[i];
            }
        }

        GameObject newObj = Instantiate(blockBlack);
        newObj.transform.SetParent(parent);
        newObj.SetActive(false);
        listBlockBlack.Add(newObj);
        return newObj;
    }

}

