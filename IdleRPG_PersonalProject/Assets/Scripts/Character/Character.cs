using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IDamageable
{
    public void BattleOrder(bool OnBattle);
    public void TakeDamage(int damage);
}

public class Character : MonoBehaviour, IDamageable
{
    public CharacterController Controller { get; private set; }
    public NavMeshAgent Agent { get; private set; }

    [field: SerializeField] public CharacterSO BaseData {  get; private set; }
    [field: SerializeField] public CharacterStatus Status { get; private set; }

    private CharacterStateMachine stateMachine;

    public GameObject Target { get; set; }
    private float searchTimer;
    private float searchRate = 0.5f;
    private bool inBattle = false;

    public int Aggro { get; private set; }
    private IAttackMethod attackMethod;

    private void Awake()
    {
        Controller = GetComponent<CharacterController>();
        Agent = GetComponent<NavMeshAgent>();
        attackMethod = GetComponent<IAttackMethod>();

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

        if(inBattle)
        {
            if(Target == null)
            {
                SetTarget();
            }

            searchTimer += Time.deltaTime;
            if(searchTimer > searchRate)
            {
                SetTarget();
            }
        }
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
        inBattle = onBattle;
    }

    public void SetTarget()
    {
        if (StageManager.Instance.enemys.Count == 0) return;

        //TODO: ĳ���Ϳ� ���� ��� ��������� �޶���
        float minDistance = float.MaxValue;

        for(int i = 0; i < StageManager.Instance.enemys.Count; i++)
        {
            float distance = Vector3.SqrMagnitude(StageManager.Instance.enemys[i].transform.position - transform.position);

            if(distance < minDistance)
            {
                Target = StageManager.Instance.enemys[i].gameObject;
                minDistance = distance;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        
    }

    public void TryAttack()
    {
        if(Target.TryGetComponent(out IDamageable damageable))
        {
            attackMethod.TryAttack(Status.Attack, damageable);
        }
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