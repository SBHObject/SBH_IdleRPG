using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class StageManager : PersistentSingleton<StageManager>
{
    public List<MapSO> maps;

    [HideInInspector]
    public List<Stage> stages;

    public GameObject waitingRoomPrefab;
    public WaitingRoom room;

    public List<Enemy> enemys;

    public int CurrentStage {  get; private set; }
    public int currentAliveEnemys;
    private bool isStageCleared = false;
    private bool gameStart = false;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        if (gameStart)
        {
            StageClearChecker();
        }
    }

    public void CreateStages(int currntMapIndex)
    {
        room = Instantiate(waitingRoomPrefab, Vector3.zero, Quaternion.identity).GetComponent<WaitingRoom>();
        Vector3 createPosition = room.stageCreatePoint.position;

        for(int i = 0; i < maps[currntMapIndex].stageCount; i++)
        {
            int index = Random.Range(0, maps[currntMapIndex].stagePrefabs.Count);
            Stage stage = Instantiate(maps[currntMapIndex].stagePrefabs[index], createPosition, Quaternion.identity).GetComponent<Stage>();
            createPosition = stage.stageCreatePoint.position;

            stages.Add(stage);
        }
        
        GetComponent<NavMeshSurface>().BuildNavMesh();
        
        //네비매시 생성후 캐릭터 생성
        room.CreateCharacters();
        CurrentStage = 0;
        stages[CurrentStage].CreateEnemy();

        gameStart = true;
        StartStage();
    }

    public void ResetMap()
    {
        stages.Clear();
        room = null;
    }

    public void StageClearChecker()
    {
        if(currentAliveEnemys == 0 && isStageCleared == false)
        {
            enemys.Clear();
            //스테이지 클리어, 다음스테이지로 이동
            isStageCleared = true;
            CurrentStage += 1;
            stages[CurrentStage].CreateEnemy();

            Invoke(nameof(StartStage), 2f);
        }
    }

    private void StartStage()
    {
        isStageCleared = false;
        GameManager.Instance.MoveToNext(stages[CurrentStage].playerPositions[0].position);

    }

    public void EnemyDie()
    {
        currentAliveEnemys--;
    }
}
