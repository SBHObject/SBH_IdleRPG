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
        if (stateMachine.Enemy.BaseData.dropItem != null && Random.Range(0f, 100f) < stateMachine.Enemy.BaseData.dropRate)
        {
            Debug.Log("¾ÆÀÌÅÛ");
            PlayerManager.Instance.inventory.AddItem(new ItemWeapon(stateMachine.Enemy.BaseData.dropItem));
        }
    }

    public override void Exit() 
    {
        base.Exit();
    }
}
