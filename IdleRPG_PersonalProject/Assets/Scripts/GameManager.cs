using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : PersistentSingleton<GameManager>
{
    //�̱��� �ν��Ͻ� ������ҿ�
    StageManager stageManager;
    PlayerManager playerManager;

    //�׽�Ʈ�� �ӽ� �̵�����
    public Transform tempPos;
    public GameObject tempTarget;
    private bool battle = false;

    private void Start()
    {
        stageManager = StageManager.Instance;
        playerManager = PlayerManager.Instance;
    }

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

        if(Input.GetKeyDown(KeyCode.D))
        {
            InitStage();
        }
    }

    public void MoveToNext()
    {
        for(int i = 0; i < playerManager.playerData.entryIndex.Count; i++)
        {
            //entryCharacters[i].MoveOrder(tempPos.position);
            
        }
    }

    public void BattleChanger(bool battleStart)
    {
        for(int i = 0; i < playerManager.playerData.entryIndex.Count;i++)
        {
            playerManager.characters[i].BattleOrder(battleStart);
            //TODO: �׽�Ʈ��, �����Ұ�...ĳ�����ʿ��� ���Ұ�
            playerManager.characters[i].MoveOrder();
        }
    }

    //�������� ���۽�, ���� ��ġ�� ĳ���� ����
    public void InitCharacters()
    {

    }

    public void InitStage()
    {
        StageManager.Instance.CreateStages(0);
    }
}
