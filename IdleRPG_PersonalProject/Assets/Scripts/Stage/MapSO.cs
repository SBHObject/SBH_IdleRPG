using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapData", menuName = "Stage/New Map")]
public class MapSO : ScriptableObject
{
    public int stageCount;
    public List<GameObject> stagePrefabs;
}
