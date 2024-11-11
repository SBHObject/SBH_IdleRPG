using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIdleState : CharacterBaseState
{
    public CharacterIdleState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.Character.Agent.isStopped = true;
        Debug.Log("대기 시작");
    }

    public override void Update()
    {
        base.Update();
        if(stateMachine.MoveOrder)
        {
            stateMachine.ChangeState(stateMachine.MoveState);
        }

        if(stateMachine.BattleOrder)
        {
            stateMachine.ChangeState(stateMachine.AttackState);
        }
    }

    public override void Exit() 
    {
        base.Exit();
        Debug.Log("대기종료");
    }
}
