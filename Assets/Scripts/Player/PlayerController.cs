using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IMoveable
{
    public PlayerData playerData;
    Vector3 dir = Vector3.zero;
    public Transform shootPoint;

    #region Movement methods
    public virtual void MoveRight()
    {
        Debug.Log(playerData.movementSpeed);
        dir = Vector3.zero;
        dir.x = playerData.movementSpeed;
        transform.Translate(dir.normalized * Time.deltaTime * playerData.movementSpeed);
    }

    public virtual void MoveLeft()
    {
        dir = Vector3.zero;
        dir.x = -playerData.movementSpeed;
        transform.Translate(dir.normalized * Time.deltaTime * playerData.movementSpeed);
    }

    public virtual void MoveForward()
    {
        dir = Vector3.zero;
        dir.z = playerData.movementSpeed;
        transform.Translate(dir.normalized * Time.deltaTime * playerData.movementSpeed);
    }

    public virtual void MoveBackward()
    {
        dir = Vector3.zero;
        dir.z = -playerData.movementSpeed;
        transform.Translate(dir.normalized * Time.deltaTime * playerData.movementSpeed);
    }

    #endregion

    #region Combat methods

    public void Shoot(ShootPoollerManager shootPooller)
    {
        var obj = shootPooller.GetPooledObject();

        if(obj != null)
        {
            obj.SetActive(true);
            obj.GetComponent<Projectile>().StartProjectile();
            obj.GetComponent<Projectile>().OnHitTarget = CountPoints;
            obj.transform.SetParent(null);
            obj.transform.position = shootPoint.transform.position;
        }
    }

    private void CountPoints()
    {
        playerData.totalPoints++;
        Debug.Log("Total Points: " + playerData.totalPoints);
    }



    #endregion
}
