using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightningSkill : BaseSkill
{
    public float damage = 50f;
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
    public override void FindTargets() {
        _units = FindObjectsOfType<BaseUnit>().Where((unit) => unit.isEnemy).ToList();
        _units.ForEach((unit) =>
        {
            SpawnParticle(unit.transform.position);
            unit.UpdateHealth(damage);
            if (unit.CurHealth == 0) {
                Destroy(unit.gameObject, 2);
            }
        });
    }
    private void SpawnParticle(Vector3 target) {
        GameObject obj = Instantiate(gObjParticle);
        obj.transform.position = new Vector3(target.x, target.y + 80, target.z);
        obj.GetComponent<ParticleSystem>().Play();
        Destroy(obj, 3);
    }
}
