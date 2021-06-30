using System;
using UnityEngine;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    public float maxLife;
    public float statusResistance;
    public float movementSpeed;
    public string enemyName;
    public StatusEffect statusEffect;
    public float currentLife;

    public void InitEnemyData()
    {
        currentLife = maxLife;
    }
}
