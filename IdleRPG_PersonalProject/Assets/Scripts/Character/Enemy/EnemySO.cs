using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Characters/new Enemy")]
public class EnemySO : ScriptableObject
{
    [SerializeField] public string enemyName;
    [SerializeField] public AttackRange RangeType;
    [SerializeField] public float AttackRange;
    [SerializeField] public int rewordMoney;
    public ItemSO dropItem;
    public float dropRate;
}

public enum AttackRange
{
    Melee,
    Ranged,
    LongRange
}