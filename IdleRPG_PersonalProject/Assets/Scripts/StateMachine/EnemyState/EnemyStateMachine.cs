using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    public Enemy Enemy { get; }

    //╩Себ╣И
    public EnemyIdleState IdleState { get; }
    public EnemyChaseState ChaseState { get; }
    public EnemyAttackState AttackState { get; }
    public EnemyDieState DieState { get; }

    public EnemyStateMachine(Enemy enemy)
    {
        Enemy = enemy;

        IdleState = new EnemyIdleState(this);
        ChaseState = new EnemyChaseState(this);
        AttackState = new EnemyAttackState(this);
        DieState = new EnemyDieState(this);
    }
}
