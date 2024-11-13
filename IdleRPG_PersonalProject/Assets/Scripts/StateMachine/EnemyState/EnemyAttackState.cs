using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    private float attackRate = 1f;
    private float attackTimer;
    public EnemyAttackState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.Enemy.Agent.isStopped = true;
    }

    public override void Update()
    {
        base.Update();
        if(IsTargetInRange() == false)
        {
            stateMachine.ChangeState(stateMachine.ChaseState);
        }

        attackTimer += Time.deltaTime;

        if(attackTimer >= attackRate)
        {
            attackTimer = 0f;
            stateMachine.Enemy.TryAttack();
        }
    }

    public override void Exit() 
    {
        base.Exit();
    }
}
