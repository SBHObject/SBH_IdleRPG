using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : PersistentSingleton<PlayerManager>
{
    private readonly int entryNumber = 4;

    [field: SerializeField] public PlayerData playerData;
    public List<GameObject> characterPrefabs;
    [HideInInspector]
    public List<Character> characters;

    public UnityAction onMoneyChange;

    public GameObject ReturnEntryCharacterPrefab(int index)
    {
        return characterPrefabs[playerData.entryIndex[index]];
    }

    public void AddMoney(int amount)
    {
        playerData.Money += amount;
        onMoneyChange?.Invoke();
    }

    public bool UseMoney(int amount)
    {
        if(playerData.Money < amount)
        {
            return false;
        }

        playerData.Money -= amount;
        onMoneyChange?.Invoke();
        return true;
    }
}

[System.Serializable]
public class PlayerData
{
    [field: SerializeField] public List<int> entryIndex;
    [field: SerializeField] public int Money { get; set; }
}
