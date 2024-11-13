using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public GameObject invenUI;

    public GameObject itemSlotPrefab;
    public Transform slotParent;
    public Scrollbar invenScroll;
    public GameObject equipButton;
    public GameObject upgradeButton;

    public ItemSlot curCharEquipSlot;
    private int curSelectCharIndex = 0;

    public UIItemSlot equipSlotUI;

    public TextMeshProUGUI charNameText;
    public TextMeshProUGUI upgradeAmountText;
    public TextMeshProUGUI upgradeCostText;
    public TextMeshProUGUI itemAttackText;

    private void Start()
    {
        for(int i = 0; i < PlayerManager.Instance.inventory.itemSlots.Count; i++)
        {
            UIItemSlot ui = Instantiate(itemSlotPrefab, slotParent).GetComponent<UIItemSlot>();
            ui.InitSlotUI(PlayerManager.Instance.inventory.itemSlots[i], false);
        }

        invenScroll.value = 1;
        equipButton.SetActive(false);

        PlayerManager.Instance.inventory.onSelectSlot += ActiveEquipButton;

        invenUI.SetActive(false);
    }

    private void GetCharacterEquipSlot(int index)
    {
        if (PlayerManager.Instance.characters[index] != null)
        {
            curCharEquipSlot = PlayerManager.Instance.characters[index].ReturnCharacterEquipSlot();
            equipSlotUI.InitSlotUI(curCharEquipSlot, true);
        }
    }

    public void ActiveEquipButton()
    {
        if (PlayerManager.Instance.inventory.CurSelecterdSlot >= 0)
        {
            equipButton.SetActive(true);
        }
    }

    public void ClickEquipButton()
    {
        curCharEquipSlot.item = PlayerManager.Instance.inventory.EquipItem();
        equipButton.SetActive(false);
        UpdateEquipItemInfo();
    }

    public void OnActiveInvenUI()
    {
        GetCharacterEquipSlot(0);
        charNameText.text = PlayerManager.Instance.characters[0].BaseData.characterName;
        UpdateEquipItemInfo();
    }

    public void ClickInventoryButton()
    {
        if(invenUI.activeInHierarchy)
        {
            invenUI.SetActive(false);
        }
        else
        {
            invenUI.SetActive(true);
            OnActiveInvenUI();
        }
    }

    public void ClickUpgradeButton()
    {
        curCharEquipSlot.item.itemUpgradeCount++;
        UpdateEquipItemInfo();
    }

    private void OnDestroy()
    {
        PlayerManager.Instance.inventory.onSelectSlot -= ActiveEquipButton;
    }

    private void UpdateEquipItemInfo()
    {
        if (curCharEquipSlot.item != null)
        {
            upgradeButton.SetActive(true);
            upgradeAmountText.text = $"+{curCharEquipSlot.item.itemUpgradeCount}";
            upgradeCostText.text = curCharEquipSlot.item.UpgradeCost.ToString();
            itemAttackText.text = curCharEquipSlot.item.ItemAttack.ToString();
        }
        else
        {
            upgradeButton.SetActive(false);
            upgradeAmountText.text = string.Empty;
            upgradeCostText.text = string.Empty;
            itemAttackText.text = string.Empty;
        }
    }
}
