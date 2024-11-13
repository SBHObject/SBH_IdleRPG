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

    public ItemSlot curCharEquip;
    private int curSelectCharIndex = 0;

    public UIItemSlot equipSlotUI;

    public TextMeshProUGUI charNameText;

    private void Start()
    {
        for(int i = 0; i < PlayerManager.Instance.inventory.itemSlots.Count; i++)
        {
            UIItemSlot ui = Instantiate(itemSlotPrefab, slotParent).GetComponent<UIItemSlot>();
            ui.InitSlotUI(PlayerManager.Instance.inventory.itemSlots[i]);
        }

        invenScroll.value = 1;
        equipButton.SetActive(false);

        PlayerManager.Instance.inventory.onSelectSlot += ActiveEquipButton;
    }

    private void GetCharacterEquipSlot(int index)
    {
        if (PlayerManager.Instance.characters[index] != null)
        {
            curCharEquip = PlayerManager.Instance.characters[index].ReturnCharacterEquipSlot();
            equipSlotUI.InitSlotUI(curCharEquip);
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
        curCharEquip.item = PlayerManager.Instance.inventory.EquipItem();
        equipButton.SetActive(false);
    }

    public void OnActiveInvenUI()
    {
        GetCharacterEquipSlot(0);
        charNameText.text = PlayerManager.Instance.characters[0].BaseData.characterName;
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
}
