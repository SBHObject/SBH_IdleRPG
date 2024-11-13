using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieState : EnemyBaseState
{
    public EnemyDieState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.Enemy.Die();
        PlayerManager.Instance.AddMoney(stateMachine.Enemy.BaseData.rewordMoney);
    }

    public override void Exit() 
    {
        base.Exit();
    }
}
