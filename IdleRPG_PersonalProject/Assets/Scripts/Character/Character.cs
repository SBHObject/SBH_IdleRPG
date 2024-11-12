using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    public CharacterController Controller { get; private set; }
    public NavMeshAgent Agent { get; private set; }

    [field: SerializeField] public CharacterSO BaseData {  get; private set; }
    [field: SerializeField] public CharacterStatus Status { get; private set; }

    private CharacterStateMachine stateMachine;

    public GameObject Target { get; set; }

    private void Awake()
    {
        Controller = GetComponent<CharacterController>();
        Agent = GetComponent<NavMeshAgent>();

        stateMachine = new CharacterStateMachine(this);
        Agent.speed = BaseData.BaseStatus.MoveSpeed;
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
    public void MoveOrder()
    {
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

[System.Serializable]
public class CharacterStatus
{
    [field: SerializeField] public int Level { get; set; }
    [field: SerializeField] public int Attack { get; set; }
    [field: SerializeField] public int Defence { get; set; }
    [field: SerializeField] public int MaxHealth { get; set; }
    [field: SerializeField] public int CurrentHealth {  get; set; }
}