using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
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
    }

    public override void Exit() 
    {
        base.Exit();
    }
}
