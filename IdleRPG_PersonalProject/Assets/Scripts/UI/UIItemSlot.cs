using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemSlot : MonoBehaviour
{
    public ItemSlot slot;
    public Image itemIcon;
    private bool isEquipSlot;

    private void Update()
    {
        UpdateSlotUI();
    }

    public void InitSlotUI(ItemSlot slot, bool isEquipSlot)
    {
        this.slot = slot;
        this.isEquipSlot = isEquipSlot;
    }

    private void UpdateSlotUI()
    {
        if(slot.item != null)
        {
            itemIcon.enabled = true;
            itemIcon.sprite = slot.item.ItemData.itemIcon;
        }
        else
        {
            itemIcon.enabled = false;
        }
    }

    public void ClickItemSlot()
    {
        PlayerManager.Instance.inventory.SlotSelect(slot.slotIndex, isEquipSlot);
    }
}
