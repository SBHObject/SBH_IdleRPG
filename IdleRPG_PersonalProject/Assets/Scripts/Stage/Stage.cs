using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public StageSO stageData;

    public Transform stageCreatePoint;

    public Transform[] enemyPositions = new Transform[3];
    public Transform[] playerPositions = new Transform[3];

    public void CreateEnemy()
    {
        
    }

    private IEnumerator CreateEnemyCoroutine()
    {
        int count = 0;
        while (count < stageData.enemyCount)
        {
            int createIndex = Random.Range(0, stageData.enemyPrefabs.Count);

            GameObject enemy = Instantiate(stageData.enemyPrefabs[createIndex], enemyPositions[0].position, Quaternion.identity);
            //TODO : 적을 초기 위치로 이동 or 처음부터 지정 위치에 생성?

            count++;
            //
            yield return new WaitForSeconds(0.5f);
        }
    }
}
