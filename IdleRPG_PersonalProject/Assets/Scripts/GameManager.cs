using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : PersistentSingleton<GameManager>
{
    public List<Character> entryCharacters = new List<Character>();

    private float maxCharacter = 4;

    private int currentMap = 0;

    //테스트용 임시 이동지점
    public Transform tempPos;
    public GameObject tempTarget;
    private bool battle = false;

    private void Update()
    {
        //TODO : 삭제 - 테스트용 강제 명령 입력
        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("이동명령");
            MoveToNext();
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
            //TODO: 테스트용, 삭제할것
            entryCharacters[i].SetTarget(tempTarget);
        }
    }

    //스테이지 시작시, 지정 위치에 캐릭터 생성
    public void InitCharacters()
    {

    }

    public void InitStage()
    {
        StageManager.Instance.CreateStages(0);
    }
}
