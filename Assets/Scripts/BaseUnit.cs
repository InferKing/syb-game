using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IHealth {
    float CurHealth { get; set; }
    float MaxHealth { get; set; }
    void UpdateHealth(float health);
}

public class BaseUnit : MonoBehaviour, IObservable, IHealth {
    protected GameObject _target;
    protected float _maxSpeed, _maxAttack;
    protected float _minSpeed, _minAttack;
    public float CurHealth { get; set; } = 0;
    public float MaxHealth { get; set; } = 0;
    public bool isEnemy = false;
    public void UpdateHealth(float health) {
        CurHealth -= health;
        CurHealth = Mathf.Clamp(CurHealth, 0, MaxHealth);
    }
    public void UpdateState(GlobalGameState state) {
        switch (state) {
            case GlobalGameState.Menu:
                break;
            case GlobalGameState.Play: 
                break;
            case GlobalGameState.Pause: 
                break;
            case GlobalGameState.End:
                break;
        }
    }
}
