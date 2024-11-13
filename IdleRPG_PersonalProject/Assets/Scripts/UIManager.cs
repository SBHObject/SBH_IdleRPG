using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public GameObject characterInfoPrefab;

    public TextMeshProUGUI moneyText;

    public Transform infoUIParent;

    private void Start()
    {
        moneyText.text = PlayerManager.Instance.playerData.Money.ToString();

        PlayerManager.Instance.onMoneyChange += UpdateMoneyText;
    }

    private void UpdateMoneyText()
    {
        moneyText.text = PlayerManager.Instance.playerData.Money.ToString();
    }

    public void InitInfoUI(Character character)
    {
        UICharacterInfo ui = Instantiate(characterInfoPrefab, infoUIParent).GetComponent<UICharacterInfo>();

        ui.InitInfoUI(character);
    }
}
