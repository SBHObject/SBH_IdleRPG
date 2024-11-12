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

    public GameObject Target { get; set; }

    private void Awake()
    {
        Controller = GetComponent<CharacterController>();
        Agent = GetComponent<NavMeshAgent>();

        stateMachine = new CharacterStateMachine(this);
        Agent.speed = Data.BaseStatus.MoveSpeed;
    }

    private void Start()
    {
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    private void Update()
    {
        stateMachine.Update();
    }

    //�̵� ���, �̵��� ��ġ ���� �ʿ�
    public void MoveOrder(Vector3 targetPosition)
    {
        Agent.SetDestination(targetPosition);
        stateMachine.MoveOrder = true;
    }

    //���� ���, ���� ���·� ����
    public void BattleOrder(bool onBattle)
    {
        stateMachine.BattleOrder = onBattle;
    }

    public void SetTarget(GameObject target)
    {
        //TODO: ĳ���Ϳ� ���� ��� ��������� �޶���
        Target = target;
    }
}
