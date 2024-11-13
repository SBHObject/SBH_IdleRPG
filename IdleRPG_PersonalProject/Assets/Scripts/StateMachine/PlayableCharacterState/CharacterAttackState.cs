using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackState : CharacterBaseState
{
    private float attackRate = 1f;
    private float attackTimer;

    public CharacterAttackState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.Character.Agent.isStopped = true;
    }

    public override void Update()
    {
        base.Update();

        //TODO : ����� ����� IdleState�� ����
        if (stateMachine.Character.Target == null || stateMachine.BattleOrder == false)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
            return;
        }

        if (IsTargetInRange())
        {
            stateMachine.Character.Agent.isStopped = true;
            //����
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackRate)
            {
                attackTimer = 0f;
                stateMachine.Character.TryAttack();
            }
        }
        else
        {
            stateMachine.ChangeState(stateMachine.ChaseState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    private bool IsTargetInRange()
    {
        if(stateMachine.Character.Agent.remainingDistance <= stateMachine.Character.BaseData.BaseStatus.AttackRange)
        {
            return true;
        }
        return false;
    }
}
