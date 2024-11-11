using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [field: SerializeField] public CharacterSO Data {  get; private set; }

    private CharacterStateMachine stateMachine;

    private void Awake()
    {
        stateMachine = new CharacterStateMachine(this);
    }

    private void Start()
    {
        stateMachine.ChangeState(stateMachine.IdleState);
    }
}
