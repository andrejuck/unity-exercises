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
            _attackCoroutine = StartCoroutine(PoisonDamage());
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Attack();
        }
    }

    IEnumerator PoisonDamage()
    {
        Debug.Log("Poison status effect started");

        int appliedTimes = 0;
        while (appliedTimes <= 10)
        {
            if(GetCurrentLife() > 0)
            {
                ApplyStatusDamage(10);
                yield return new WaitForSeconds(1);
                appliedTimes++;
                Debug.Log($"Life after poison damage: {GetCurrentLife()}");
            }
            else
            {
                Debug.Log("Enemy died poisoned");
                break;
            }
        }

        Debug.Log("Poison status effect finished");
    }

    void Attack()
    {
        Debug.Log("Enemy attacked started");

        OnDamage(1);
        float life = GetCurrentLife();

        Debug.Log($"Current life: {life}");
        if (life <= 0)
        {
            Debug.Log("Enemy died");
        }
    }
}
