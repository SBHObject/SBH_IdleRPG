using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    public List<ItemSlot> itemSlots = new List<ItemSlot>(100);

    public Inventory()
    {
        for (int i = 0; i < 100; i++)
        {
            itemSlots.Add(new ItemSlot());
            itemSlots[i].slotIndex = i;
        }
    }

    public void AddItem(ItemSO item)
    {
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (itemSlots[i].item == null)
            {
                itemSlots[i].item = item;
                return;
            }
        }

        SellItem(item);
    }

    public void SellItem(ItemSO item)
    {
        PlayerManager.Instance.AddMoney(item.itemPrice);
    }

    public void RemoveItem(int slotIndex)
    {
        itemSlots[slotIndex].item = null;
    }
}
