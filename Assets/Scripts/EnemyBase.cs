using UnityEngine;

public class EnemyBase : MonoBehaviour, IStatusEffect, IDamageable
{

    public EnemyData enemyData;

    private void Awake()
    {
        enemyData.InitEnemyData();
    }

    #region Overrideables
    public virtual void OnDamage(float damage)
    {
        if(enemyData.currentLife > 0)
        {
            enemyData.currentLife -= damage;
        }
    }

    public virtual void ApplyStatusDamage(float baseStatusDamage)
    {
        if (enemyData.statusEffect.Equals(StatusEffect.None)) return;

        if(enemyData.currentLife > 0)
        {
            float statusDamage = baseStatusDamage - (baseStatusDamage * enemyData.statusResistance);
            Debug.Log(statusDamage.ToString());
            enemyData.currentLife -= statusDamage;
        }
    }
    #endregion

    #region Getters/Setters
    public void SetStatus(StatusEffect effect)
    {
        enemyData.statusEffect = effect;
    }

    public StatusEffect GetStatus() => enemyData.statusEffect;
    public float GetCurrentLife() => enemyData.currentLife;
    #endregion
}
