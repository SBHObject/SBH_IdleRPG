using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stage", menuName ="Stage/New Stage")]
public class StageSO : ScriptableObject
{
    public int enemyCount;

    public List<GameObject> enemyPrefabs;
}
