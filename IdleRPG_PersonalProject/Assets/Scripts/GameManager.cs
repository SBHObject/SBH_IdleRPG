using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        SceneManager.sceneLoaded += OnSceneLoaded;

        InitStage();
    }

    private void Update()
    {
        //TODO : ���� - �׽�Ʈ�� ���� ��� �Է�
        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("�̵����");
            //MoveToNext();
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

    public void MoveToNext(Vector3 position)
    {
        for(int i = 0; i < playerManager.playerData.entryIndex.Count; i++)
        {
            playerManager.characters[i].Agent.SetDestination(position);
            playerManager.characters[i].MoveOrder();
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

    public void InitStage()
    {
        stageManager.CreateStages(0);
    }

    public void SceneReload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayerManager.Instance.characters.Clear();
        InitStage();
    }
}
