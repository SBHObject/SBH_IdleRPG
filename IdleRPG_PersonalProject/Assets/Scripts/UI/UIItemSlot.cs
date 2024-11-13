using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemSlot : MonoBehaviour
{
    public ItemSlot slot;
    public Image itemIcon;

    private void Update()
    {
        UpdateSlotUI();
    }

    public void InitSlotUI(ItemSlot slot)
    {
        this.slot = slot;
    }

    private void UpdateSlotUI()
    {
        if(slot.item != null)
        {
            itemIcon.sprite = slot.item.itemIcon;
        }
        else
        {
            itemIcon.enabled = false;
        }
    }
}
