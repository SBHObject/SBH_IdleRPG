using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    public CharacterController Controller { get; private set; }
    public NavMeshAgent Agent { get; private set; }

    [field: SerializeField] public CharacterSO Data {  get; private set; }

    private CharacterStateMachine stateMachine;

    private void Awake()
    {
        Controller = GetComponent<CharacterController>();
        Agent = GetComponent<NavMeshAgent>();

        stateMachine = new CharacterStateMachine(this);
    }

    private void Start()
    {
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    private void Update()
    {
        stateMachine.Update();
    }

    //이동 명령, 이동할 위치 지정 필요
    public void MoveOrder()
    {
        stateMachine.MoveOrder = true;
    }

    //전투 명령, 전투 상태로 변경
    public void BattleOrder()
    {
        stateMachine.BattleOrder = true;
    }
}
