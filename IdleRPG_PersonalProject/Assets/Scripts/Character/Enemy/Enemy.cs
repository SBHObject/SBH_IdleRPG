using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamageable
{
    public NavMeshAgent Agent { get; private set; }
    public CharacterController Controller { get; private set; }

    [field:SerializeField] public EnemySO BaseData { get; private set; }

    private EnemyStateMachine stateMachine;
    private bool inBattle = false;
    private float searchTimer;
    private float searchRate = 0.5f;

    public GameObject Target { get; private set; }

    private int tempHealth = 100;
    private int tempAttack = 10;
    private IAttackMethod attackMethod;

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        Controller = GetComponent<CharacterController>();
        stateMachine = new EnemyStateMachine(this);
        attackMethod = GetComponent<IAttackMethod>();
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
            searchTimer += Time.deltaTime;
            if(searchTimer > searchRate)
            {
                SearchTarget();
                searchTimer = 0;
            }
        }
    }

    private void SearchTarget()
    {
        int maxAggro = int.MinValue;
        for (int i = 0; i < PlayerManager.Instance.characters.Count; i++)
        {
            if (PlayerManager.Instance.characters[i].Aggro > maxAggro)
            {
                Target = PlayerManager.Instance.characters[i].gameObject;
                maxAggro = PlayerManager.Instance.characters[i].Aggro;
            }
        }
    }

    public void BattleOrder(bool OnBattle)
    {
        stateMachine.ChangeState(stateMachine.ChaseState);
        SearchTarget();
    }

    public void TakeDamage(int damage)
    {
        tempHealth -= damage;

        if(tempHealth <= 0)
        {
            stateMachine.ChangeState(stateMachine.DieState);
        }
    }

    public void TryAttack()
    {
        if(Target.TryGetComponent(out IDamageable damageable))
        {
            attackMethod.TryAttack(tempAttack, damageable);
        }
    }

    public void Die()
    {
        StageManager.Instance.EnemyDie();
        StageManager.Instance.enemys.Remove(this);
        Destroy(gameObject);
    }
}
