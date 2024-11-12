using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseState : IState
{
    protected EnemyStateMachine stateMachine;
    public EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        
    }

    public virtual void Exit()
    {
        
    }

    public virtual void PhysicsUpdate()
    {
        
    }

    public virtual void Update()
    {
        
    }

    protected bool IsTargetInRange()
    {
        if (stateMachine.Enemy.Target == null) return false;

        float distance = Vector3.SqrMagnitude(stateMachine.Enemy.Target.transform.position - stateMachine.Enemy.transform.position);

        if (distance < stateMachine.Enemy.BaseData.AttackRange * stateMachine.Enemy.BaseData.AttackRange)
        {
            stateMachine.ChangeState(stateMachine.AttackState);
            return true;
        }

        return false;
    }
}
