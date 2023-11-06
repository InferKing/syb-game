using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

interface IHealth {
    float CurHealth { get; set; }
    float MaxHealth { get; set; }
    void UpdateHealth(float health);
}
public enum UnitState { 
    Idle, 
    Run,
    Attack,
    Death
}

public class BaseUnit : MonoBehaviour, IObservable, IHealth {
    [SerializeField] protected NavMeshAgent _agent;
    protected GameObject _target;
    protected Animator _animator;
    protected UnitState _unitState = UnitState.Idle;
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
    public void MoveTo(Vector3 target)
    {
        if (target == null) return;
        _agent.SetDestination(target);
        Debug.Log(target);
    }
    public void UpdateState(UnitState state)
    {
        _unitState = state;
        _animator.SetBool("Idle", state is UnitState.Idle);
        _animator.SetBool("Run", state is UnitState.Run);
        _animator.SetBool("Attack", state is UnitState.Attack);
        _animator.SetBool("Death", state is UnitState.Death);
    }
}
