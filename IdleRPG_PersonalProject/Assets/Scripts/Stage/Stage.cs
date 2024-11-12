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
        StageManager.Instance.currentAliveEnemys = stageData.enemyCount;
        int count = 0;
        int melee = 0;
        int range = 0;
        int longRange = 0;
        while (count < stageData.enemyCount)
        {
            int createIndex = Random.Range(0, stageData.enemyPrefabs.Count);
            Vector3 position;

            switch (stageData.enemyPrefabs[createIndex].GetComponent<Enemy>().BaseData.RangeType)
            {
                case AttackRange.Melee:
                    position = enemyPositions[2].position;
                    position = melee % 2 == 0 ? position + Vector3.right * melee * 2 : position + Vector3.left * melee * 2;
                    melee++;
                    break;
                case AttackRange.Ranged:
                    position = enemyPositions[1].position;
                    position = range % 2 == 0 ? position + Vector3.right * range * 2 : position + Vector3.left * range * 2;
                    range++;
                    break;
                case AttackRange.LongRange:
                    position = enemyPositions[0].position;
                    position = longRange % 2 == 0 ? position + Vector3.right * longRange * 2 : position + Vector3.left * longRange * 2;
                    longRange++;
                    break;
                default:
                    position = enemyPositions[0].position;
                    break;
            }

            GameObject enemy = Instantiate(stageData.enemyPrefabs[createIndex], position, Quaternion.identity);
            //TODO : 적을 초기 위치로 이동 or 처음부터 지정 위치에 생성?
            StageManager.Instance.enemys.Add(enemy.GetComponent<Enemy>());

            count++;
        }
    }
}
