using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : PersistentSingleton<GameManager>
{
    public List<Character> entryCharacters = new List<Character>();

    private float maxCharacter = 4;

    //�׽�Ʈ�� �ӽ� �̵�����
    public Transform tempPos;
    public GameObject tempTarget;
    private bool battle = false;

    private void Update()
    {
        //TODO : ���� - �׽�Ʈ�� ���� ��� �Է�
        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("�̵����");
            MoveToNext();
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("���ݸ��");
            BattleChanger(!battle);
            battle = !battle;
        }
    }

    public void MoveToNext()
    {
        for(int i = 0; i < entryCharacters.Count; i++)
        {
            entryCharacters[i].Agent.SetDestination(tempPos.position);
            entryCharacters[i].MoveOrder();
        }
    }

    public void BattleChanger(bool battleStart)
    {
        for(int i = 0; i < entryCharacters.Count;i++)
        {
            entryCharacters[i].BattleOrder(battleStart);
            //TODO: �׽�Ʈ��, �����Ұ�
            entryCharacters[i].SetTarget(tempTarget);
        }
    }

    //�������� ���۽�, ���� ��ġ�� ĳ���� ����
    public void InitCharacters()
    {

    }
}
