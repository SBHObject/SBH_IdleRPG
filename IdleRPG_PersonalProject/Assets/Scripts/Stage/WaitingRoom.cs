using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingRoom : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public Transform stageCreatePoint;

    public void CreateCharacters()
    {
        GameObject character = Instantiate(GameManager.Instance.characterPrefab, spawnPoints[0].position, Quaternion.identity);
        GameManager.Instance.entryCharacters.Add(character.GetComponent<Character>());
        Debug.Log(GameManager.Instance.entryCharacters[0].Agent.navMeshOwner);
    }
}
