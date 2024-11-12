using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent Agent { get; private set; }
    public CharacterController Controller { get; private set; }

    [field:SerializeField] public EnemySO BaseData { get; private set; }

    private EnemyStateMachine stateMachine;

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        Controller = GetComponent<CharacterController>();
        stateMachine = new EnemyStateMachine(this);
    }

    private void Start()
    {
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    private void Update()
    {
        stateMachine.Update();
    }
}
