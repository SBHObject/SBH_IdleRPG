using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Characters/PlayableCharacter")]
public class CharacterSO : ScriptableObject
{
    [field: SerializeField] public CharacterStatus BaseStatus { get; private set; }
}

[System.Serializable]
public class CharacterStatus
{
    [field: SerializeField] public int BaseHealth { get; private set; }
    [field: SerializeField] public float MoveSpeed { get; private set; }

    [field: Header("Combat")]
    [field: SerializeField] public float AttackRange { get; private set; }
    [field: SerializeField] public float BaseAttackDamage { get; private set; }
    [field: SerializeField] public int BaseDefence { get; private set; }

    [field: Header("Growth")]
    [field: SerializeField] public float GrowthHealthPerLevel {  get; private set; }
    [field: SerializeField] public float GrowthAttackPerLevel { get; private set; }
    [field: SerializeField] public float GrowthDefencePerLevel {  get; private set; }
}
