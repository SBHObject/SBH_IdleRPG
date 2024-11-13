using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory : MonoBehaviour
{
    public List<ItemSlot> itemSlots = new List<ItemSlot>(100);

    private void Awake()
    {
        for(int i = 0; i < 100; i++)
        {
            itemSlots.Add(new ItemSlot());
            itemSlots[i].slotIndex = i;
        }
    }

    public void AddItem(ItemSO item)
    {
        
    }
}
