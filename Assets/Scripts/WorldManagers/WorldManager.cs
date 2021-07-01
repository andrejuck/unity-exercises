using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public EnemyPoolManager enemyPool;

    private Coroutine _enemyPoolCoroutine;

    private void Start()
    {
        _enemyPoolCoroutine = StartCoroutine(SpawnEnemy());
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Tab))
        //{
        //    SpawnEnemy();
        //}
    }

    IEnumerator SpawnEnemy()
    {

        while (enemyPool.GetInactivePooledObjects().Any())
        {
            var obj = enemyPool.GetPooledObject();
            var area = GameObject.Find("Plane");
            var spawnPointX = Random.Range(
                -area.transform.localScale.x / obj.transform.localScale.x,
                area.transform.localScale.x / obj.transform.localScale.x
                );
            var spawnPointZ = Random.Range(
                -area.transform.localScale.z / obj.transform.localScale.z,
                area.transform.localScale.z / obj.transform.localScale.z
                );
            var spawnArea = new Vector3(spawnPointX, 0.25f, spawnPointZ);

            if (obj != null)
            {
                obj.SetActive(true);
                obj.transform.position = spawnArea;
                //Set random movement;
            }

            yield return new WaitForSeconds(5);
        }
    }
}
