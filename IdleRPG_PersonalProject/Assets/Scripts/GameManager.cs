using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : PersistentSingleton<GameManager>
{
    //싱글톤 인스턴스 길이축소용
    StageManager stageManager;
    PlayerManager playerManager;

    //테스트용 임시 이동지점
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
        //TODO : 삭제 - 테스트용 강제 명령 입력
        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("이동명령");
            //MoveToNext();
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("공격명령");
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
            //TODO: 테스트용, 삭제할것...캐릭터쪽에서 정할것
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
