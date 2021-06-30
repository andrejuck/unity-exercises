using UnityEngine;

public class EnemyBase : MonoBehaviour, IStatusEffect, IDamageable, IMoveable
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

    public void ApplyStatusDamage(float baseStatusDamage)
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

    #region Movement methods
    public virtual void MoveRight()
    {
        Vector3 newPosition = new Vector3(transform.position.x + enemyData.movementSpeed, transform.position.y, transform.position.z);
        transform.Translate(newPosition);
    }

    public virtual void MoveLeft()
    {
        Vector3 newPosition = new Vector3(transform.position.x - enemyData.movementSpeed, transform.position.y, transform.position.z);
        transform.Translate(newPosition);
    }

    public virtual void MoveForward()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + enemyData.movementSpeed);
        transform.Translate(newPosition);
    }

    public virtual void MoveBackward()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - enemyData.movementSpeed);
        transform.Translate(newPosition);
    }
    #endregion
}
