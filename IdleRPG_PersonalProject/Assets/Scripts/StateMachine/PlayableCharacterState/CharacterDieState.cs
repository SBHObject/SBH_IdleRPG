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
        //��� ����, �� ��Ȱ��ȭ
        //�ӽ÷� ��� ��Ȱ...
        stateMachine.Character.Status.CurrentHealth = stateMachine.Character.Status.MaxHealth;
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    public override void Exit() 
    {
        base.Exit();
        //TODO : ��Ȱ, ü�� ȸ���� ��� �߰�
    }
}
