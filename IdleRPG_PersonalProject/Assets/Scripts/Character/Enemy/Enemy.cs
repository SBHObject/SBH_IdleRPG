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
    private bool inBattle = false;
    private float searchTimer;
    private float searchRate = 0.5f;

    public GameObject Target { get; private set; }

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

    public void BattleOrder()
    {
        stateMachine.ChangeState(stateMachine.ChaseState);
        SearchTarget();
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
}
