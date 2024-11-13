using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public interface IDamageable
{
    public void BattleOrder(bool OnBattle);
    public void TakeDamage(int damage);
}

public class Character : MonoBehaviour, IDamageable
{
    public CharacterController Controller { get; private set; }
    public NavMeshAgent Agent { get; private set; }

    [field: SerializeField] public CharacterSO BaseData { get; private set; }
    [field: SerializeField] public CharacterStatus Status { get; private set; }

    private CharacterStateMachine stateMachine;

    public GameObject Target { get; set; }
    private float searchTimer;
    private float searchRate = 0.5f;
    private bool inBattle = false;

    public int Aggro { get; private set; }
    private IAttackMethod attackMethod;

    public UnityAction onHpChange;

    private ItemSlot equipSlot;

    private void Awake()
    {
        Controller = GetComponent<CharacterController>();
        Agent = GetComponent<NavMeshAgent>();
        attackMethod = GetComponent<IAttackMethod>();
        equipSlot = new ItemSlot();

        stateMachine = new CharacterStateMachine(this);
        Agent.speed = BaseData.BaseStatus.MoveSpeed;

        Status = new CharacterStatus(BaseData.BaseStatus.BaseAttackDamage, BaseData.BaseStatus.BaseDefence, BaseData.BaseStatus.BaseHealth); ;
    }

    private void Start()
    {
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    private void Update()
    {
        stateMachine.Update();

        if (inBattle)
        {
            if (Target == null)
            {
                SetTarget();
            }

            searchTimer += Time.deltaTime;
            if (searchTimer > searchRate)
            {
                SetTarget();
            }
        }
    }

    //이동 명령, 이동할 위치 지정 필요
    public void MoveOrder()
    {
        stateMachine.MoveOrder = true;
    }

    //전투 명령, 전투 상태로 변경
    public void BattleOrder(bool onBattle)
    {
        stateMachine.BattleOrder = onBattle;
        inBattle = onBattle;
    }

    public void SetTarget()
    {
        if (StageManager.Instance.enemys.Count == 0) return;

        //TODO: 캐릭터에 따라 대상 지정방법이 달라짐
        float minDistance = float.MaxValue;

        for (int i = 0; i < StageManager.Instance.enemys.Count; i++)
        {
            float distance = Vector3.SqrMagnitude(StageManager.Instance.enemys[i].transform.position - transform.position);

            if (distance < minDistance)
            {
                Target = StageManager.Instance.enemys[i].gameObject;
                minDistance = distance;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        Status.CurrentHealth = Status.CurrentHealth - damage < 0 ? 0 : Status.CurrentHealth - damage;
        if (Status.CurrentHealth == 0)
        {
            stateMachine.ChangeState(stateMachine.DieState);
        }

        onHpChange?.Invoke();
    }

    public void TryAttack()
    {
        if (Target.TryGetComponent(out IDamageable damageable))
        {
            attackMethod.TryAttack(Status.Attack, damageable);
        }
    }

    public ItemSlot ReturnCharacterEquipSlot()
    {
        return equipSlot;
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

    public CharacterStatus(int attack, int defence, int maxHealth)
    {
        Level = 1;
        Attack = attack;
        Defence = defence;
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
    }
}