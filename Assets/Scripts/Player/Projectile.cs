using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction;
    public float projectileSpeed;
    public string tagToLook = "Enemy";

    public Action OnHitTarget;

    private void Update()
    {
        transform.Translate(direction * Time.deltaTime * projectileSpeed);
    }

    public void StartProjectile()
    {
        Invoke(nameof(FinishUsage), 5);
    }

    private void FinishUsage()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag.Equals(tagToLook))
        {
            collision.gameObject.SetActive(false);
            OnHitTarget?.Invoke();
            FinishUsage();
        }
    }
}
