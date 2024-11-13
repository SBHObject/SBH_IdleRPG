using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingRoom : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public Transform stageCreatePoint;

    public void CreateCharacters()
    {
        for(int i = 0; i < PlayerManager.Instance.playerData.entryIndex.Count; i++)
        {
            GameObject character = Instantiate(PlayerManager.Instance.ReturnEntryCharacterPrefab(i), StageManager.Instance.room.spawnPoints[i].position, Quaternion.identity);
            PlayerManager.Instance.characters.Add(character.GetComponent<Character>());
            UIManager.Instance.InitInfoUI(character.GetComponent<Character>());
        }
    }
}
