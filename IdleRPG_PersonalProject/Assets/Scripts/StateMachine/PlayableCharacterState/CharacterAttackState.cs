using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackState : CharacterBaseState
{
    public CharacterAttackState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        //TODO : ����� ����� IdleState�� ����

        if(IsTargetInRange())
        {
            stateMachine.Character.Agent.isStopped = true;
            //����
        }
        else
        {
            stateMachine.Character.Agent.isStopped = false;
            //
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    private bool IsTargetInRange()
    {
        if(stateMachine.Character.Agent.remainingDistance <= stateMachine.Character.Data.BaseStatus.AttackRange)
        {
            return true;
        }
        return false;
    }
}
