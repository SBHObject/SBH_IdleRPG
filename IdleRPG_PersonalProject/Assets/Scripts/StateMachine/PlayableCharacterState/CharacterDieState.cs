using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDieState : CharacterBaseState
{
    public CharacterDieState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        //stateMachine.Character.Agent.isStopped = true;
        //사망 상태, 모델 비활성화
        //임시로 즉시 부활...
        stateMachine.Character.Status.CurrentHealth = stateMachine.Character.Status.MaxHealth;
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    public override void Exit() 
    {
        base.Exit();
        //TODO : 부활, 체력 회복등 기능 추가
    }
}
