using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPoolManager : MonoBehaviour, IPooller
{
    public GameObject enemyPrefab;
    public List<GameObject> enemyPrefabList;
    public int enemyAmount;

    private void Awake()
    {
        StartPool();
    }

    public void StartPool()
    {
        enemyPrefabList = new List<GameObject>();
        for (int i = 0; i < enemyAmount; i++)
        {
            var obj = Instantiate(enemyPrefab, transform);
            obj.SetActive(false);
            enemyPrefabList.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < enemyAmount; i++)
        {
            if (!enemyPrefabList[i].activeInHierarchy)
            {
                return enemyPrefabList[i];
            }
        }

        return null;
    }

    public List<GameObject> GetInactivePooledObjects()
    {
        var inactives = enemyPrefabList.Where(x => x.activeInHierarchy.Equals(false)).ToList();
        return inactives;
    } 
}
