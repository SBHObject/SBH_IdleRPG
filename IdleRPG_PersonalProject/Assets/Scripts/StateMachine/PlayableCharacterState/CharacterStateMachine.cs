using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateMachine : StateMachine
{
    public Character Character { get; }

    //»óÅÂµé
    public CharacterIdleState IdleState { get; }
    public CharacterAttackState AttackState { get; }
    public CharacterMoveState MoveState { get; }
    public CharacterDieState DieState { get; }

    public CharacterStateMachine(Character character)
    {
        Character = character;

        IdleState = new CharacterIdleState(this);
        AttackState = new CharacterAttackState(this);
        MoveState = new CharacterMoveState(this);
        DieState = new CharacterDieState(this);
    }
}
