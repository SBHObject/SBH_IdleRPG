using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour, IAttackMethod
{
    public MeleeWeapon weapon;

    public void TryAttack(int damage, IDamageable target)
    {
        weapon.SetDamage(damage);
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        weapon.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        weapon.gameObject.SetActive(false);
    }

}
