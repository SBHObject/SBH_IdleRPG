using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : PersistentSingleton<GameManager>
{
    public List<Character> entryCharacters = new List<Character>();

    private float maxCharacter = 4;

    //�׽�Ʈ�� �ӽ� �̵�����
    public Transform tempPos;

    private void Update()
    {
        //TODO : ���� - �׽�Ʈ�� ���� ��� �Է�
        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("�̵����");
            MoveToNext();
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

    //�������� ���۽�, ���� ��ġ�� ĳ���� ����
    public void InitCharacters()
    {

    }
}
