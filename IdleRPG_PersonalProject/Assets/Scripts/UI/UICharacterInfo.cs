using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterInfo : MonoBehaviour
{
    public Image icon;
    public Image hpBar;

    private Character info;

    public void InitInfoUI(Character character)
    {
        info = character;

        icon.sprite = info.BaseData.characterIcon;
        info.onHpChange += UpdateHpBar;
    }

    public void UpdateHpBar()
    {
        float amount = (float)info.Status.CurrentHealth / info.Status.MaxHealth;
        hpBar.fillAmount = amount;
    }

    private void OnDisable()
    {
        info.onHpChange -= UpdateHpBar;
    }
}
