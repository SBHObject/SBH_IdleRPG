using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveState : CharacterBaseState
{
    public CharacterMoveState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.Character.Agent.isStopped = false;
    }

    public override void Update()
    {
        base.Update();
        if(IsArrived())
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.MoveOrder = false;
    }

    private bool IsArrived()
    {
        if(stateMachine.Character.Agent.remainingDistance <= 0.1f)
        {
            return true;
        }

        return false;
    }
}
