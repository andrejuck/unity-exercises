using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : EnemyBase
{
    private Coroutine _attackCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("EnemyBasic started");
    }

    // Update is called once per frame
    void Update()
    {
        //Code to test the damage coroutine
        if (Input.GetKeyDown(KeyCode.Space) && _attackCoroutine == null)
        {
            
            _attackCoroutine = StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        Debug.Log("Attack coroutine started");
        float life = GetCurrentLife();

        for (int i = 0; i <= life; i++)
        {
            OnDamage(1);
            float newLife = GetCurrentLife();

            Debug.Log($"Current life: {newLife}");
            if (newLife <= 0)
            {
                Debug.Log("Enemy died");
                yield break;
            }

            yield return new WaitForSeconds(1);
        }
    }
}
