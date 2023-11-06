using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBuilding : MonoBehaviour, IHealth
{
    public float CurHealth { get; set; } = 0;
    public float MaxHealth { get; set; } = 0;
    public bool isEnemy = false;
    public void UpdateHealth(float health)
    {
        CurHealth -= health;
        CurHealth = Mathf.Clamp(CurHealth, 0, MaxHealth);
    }

}
