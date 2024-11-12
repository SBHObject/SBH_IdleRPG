using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class StageManager : PersistentSingleton<StageManager>
{
    private NavMeshSurface meshSurface;
    public List<MapSO> maps;

    [HideInInspector]
    public List<GameObject> stages;

    public GameObject waitingRoomPrefab;

    protected override void Awake()
    {
        base.Awake();
        meshSurface = GetComponent<NavMeshSurface>();
    }

    public void CreateStages(int currntMapIndex)
    {
        GameObject room = Instantiate(waitingRoomPrefab, Vector3.zero, Quaternion.identity);
        Vector3 createPosition = room.GetComponent<WaitingRoom>().stageCreatePoint.position;

        for(int i = 0; i < maps[currntMapIndex].stageCount; i++)
        {
            int index = Random.Range(0, maps[currntMapIndex].stagePrefabs.Count);
            GameObject stage = Instantiate(maps[currntMapIndex].stagePrefabs[index], createPosition, Quaternion.identity);
            createPosition = stage.GetComponent<Stage>().stageCreatePoint.position;

            stages.Add(stage);
        }

        //맵 생성후, 네비매시 생성
        meshSurface.BuildNavMesh();
    }

    public void ResetMap()
    {
        stages.Clear();
    }
}
