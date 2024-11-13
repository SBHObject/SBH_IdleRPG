using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackMethod
{
    public void TryAttack(int damage, IDamageable target);
}

public class RangeAttack : MonoBehaviour, IAttackMethod
{
    public void TryAttack(int damage, IDamageable target)
    {
        target.TakeDamage(damage);
    }
}
