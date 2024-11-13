using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Inventory
{
    public List<ItemSlot> itemSlots = new List<ItemSlot>(100);
    public int CurSelecterdSlot { get; private set; } = -1;

    public UnityAction onSelectSlot;

    public Inventory()
    {
        for (int i = 0; i < 100; i++)
        {
            itemSlots.Add(new ItemSlot());
            itemSlots[i].slotIndex = i;
        }
    }

    public void AddItem(ItemWeapon item)
    {
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (itemSlots[i].item == null)
            {
                itemSlots[i].item = item;
                return;
            }
        }

        SellItem(item.ItemData);
    }

    public void SellItem(ItemSO item)
    {
        PlayerManager.Instance.AddMoney(item.itemPrice);
    }

    public void RemoveItem(int slotIndex)
    {
        itemSlots[slotIndex].item = null;
    }

    public void SlotSelect(int index, bool activeButton)
    {
        CurSelecterdSlot = index;
        if (activeButton == false)
        {
            onSelectSlot?.Invoke();
        }
    }

    public ItemWeapon EquipItem()
    {
        ItemWeapon item = itemSlots[CurSelecterdSlot].item;
        itemSlots[CurSelecterdSlot].item = null;
        CurSelecterdSlot = -1;

        return item;
    }
}
