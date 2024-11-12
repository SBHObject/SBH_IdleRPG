using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : PersistentSingleton<PlayerManager>
{
    private readonly int entryNumber = 4;

    [field: SerializeField] public PlayerData playerData;
    public List<GameObject> characterPrefabs;
    //[HideInInspector]
    public List<Character> characters;

    public GameObject ReturnEntryCharacterPrefab(int index)
    {
        return characterPrefabs[playerData.entryIndex[index]];
    }
}

[System.Serializable]
public class PlayerData
{
    [field: SerializeField] public List<int> entryIndex;
}
