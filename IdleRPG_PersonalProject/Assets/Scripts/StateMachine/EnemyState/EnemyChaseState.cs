using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    public EnemyChaseState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.Enemy.Agent.isStopped = false;
    }

    public override void Update()
    {
        base.Update();
        if(IsTargetInRange())
        {
            stateMachine.ChangeState(stateMachine.AttackState);
        }
        
        if(stateMachine.Enemy.Target != null)
        {
            stateMachine.Enemy.Agent.SetDestination(stateMachine.Enemy.Target.transform.position);
        }
        else
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }

    public override void Exit() 
    {
        base.Exit();
    }
}
