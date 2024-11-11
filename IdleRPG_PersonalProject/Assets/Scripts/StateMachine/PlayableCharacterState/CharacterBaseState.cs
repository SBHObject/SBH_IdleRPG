using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBaseState : IState
{
    protected CharacterStateMachine stateMachine;

    public CharacterBaseState(CharacterStateMachine stateMachine)
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
}
