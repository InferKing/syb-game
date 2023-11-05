using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : MonoBehaviour
{
    protected List<BaseUnit> _units;
    [SerializeField] protected GameObject gObjParticle;
    public float curTime = 0;
    public readonly float cooldown = 10f;
    public readonly float price = 1000f;
    public abstract bool TryPlaySkill();
    public abstract void FindTargets();
    public bool IsCooldown() => curTime > 0;
    public float OstTime() => curTime;
    public float CoefOstTime() => curTime / cooldown;
    protected IEnumerator Delay() {
        curTime = cooldown;
        while (curTime > 0) { 
            curTime -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        curTime = 0;
    }
    public void PlaySkill()
    {
        if (IsCooldown()) return;
        StartCoroutine(Delay());
        FindTargets();
    }
}
