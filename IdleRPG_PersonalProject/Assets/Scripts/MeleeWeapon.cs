using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public LayerMask targetLayer;

    private List<Collider> targets = new List<Collider>();

    private int damage;

    private void OnEnable()
    {
        targets.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (targets.Contains(other)) return;
        //if (other.gameObject.layer != targetLayer) return;

        targets.Add(other);

        if(other.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(damage);
        }
    }

    public void SetDamage(int nowDamage)
    {
        damage = nowDamage;
    }
}
