using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FireballSkill : BaseSkill
{
    public float damage = 100f;
    public float radius = 10f;
    private void Start()
    {
        _units = new List<BaseUnit>();
    }
    public override bool TryPlaySkill()
    {
        if (IsCooldown()) return false;
        StartCoroutine(Delay());
        return true;
    }
    public override void FindTargets()
    {
        int most = 0;
        Vector3 target = new Vector3();
        _units = FindObjectsOfType<BaseUnit>().Where((unit) => unit.isEnemy).ToList();
        _units.ForEach((unit) =>
        {
            int result = 0;
            _units.ForEach(unit2 => {
                if (Vector3.Distance(unit.transform.position, unit2.transform.position) < radius) result++;
            });
            if (result > most)
            {
                most = result;
                target = unit.transform.position;
            }
        });
        if (most != 0) {
            SpawnParticle(target);
            _units.ForEach((unit) =>
            {
                if (Vector3.Distance(unit.transform.position, target) < radius)
                {
                    BaseUnit temp = unit.GetComponent<BaseUnit>();
                    temp.UpdateHealth(damage);
                    if (temp.CurHealth == 0)
                    {
                        Destroy(temp.gameObject, 1);
                    }
                }
            });
            
        }
    }
    private void SpawnParticle(Vector3 target)
    {
        GameObject obj = Instantiate(gObjParticle);
        obj.transform.position = new Vector3(target.x, target.y + 120, target.z);
        obj.GetComponent<ParticleSystem>().Play();
        Destroy(obj, 3);
    }
}
