using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPoollerManager : MonoBehaviour, IPooller
{
    public GameObject projectilePrefab;
    public List<GameObject> projectilePrefabList;
    public int amountProjectile;

    private void Awake()
    {
        StartPool();
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountProjectile; i++)
        {
            if (!projectilePrefabList[i].activeInHierarchy)
            {
                return projectilePrefabList[i];
            }
        }

        return null;
    }

    public void StartPool()
    {
        projectilePrefabList = new List<GameObject>();
        for (int i = 0; i < amountProjectile; i++)
        {
            var obj = Instantiate(projectilePrefab, transform);
            obj.SetActive(false);
            projectilePrefabList.Add(obj);
        }
    }
}
