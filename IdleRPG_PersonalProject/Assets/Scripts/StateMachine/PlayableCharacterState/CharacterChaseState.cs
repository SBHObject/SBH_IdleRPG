using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChaseState : CharacterBaseState
{
    private float searchRate = 0.5f;
    private float searchTimer;

    public CharacterChaseState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.Character.Agent.isStopped = false;
        stateMachine.Character.Agent.SetDestination(stateMachine.Character.Target.transform.position);
    }

    public override void Update()
    {
        base.Update();

        if(stateMachine.Character.Target == null || stateMachine.BattleOrder == false)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
            return;
        }

        searchTimer += Time.deltaTime;

        IsTargetInRange();

        if( searchTimer >= searchRate)
        {
            stateMachine.Character.Agent.SetDestination(stateMachine.Character.Target.transform.position);
            searchTimer = 0;
        }
    }

    public override void Exit() 
    { 
        base.Exit();
        searchTimer = 0;
    }

    private void IsTargetInRange()
    {
        if(stateMachine.Character.Agent.remainingDistance <= stateMachine.Character.BaseData.BaseStatus.AttackRange)
        {
            stateMachine.ChangeState(stateMachine.AttackState);
        }
    }
}
