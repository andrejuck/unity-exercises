using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    public float maxLife;
    public float currentLife;
    public float movementSpeed;
    public int totalPoints;
}
