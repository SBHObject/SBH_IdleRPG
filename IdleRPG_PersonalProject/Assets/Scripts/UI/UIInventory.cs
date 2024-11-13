using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public GameObject itemSlotPrefab;
    public Transform slotParent;

    private void Start()
    {
        for(int i = 0; i < PlayerManager.Instance.inventory.itemSlots.Count; i++)
        {
            UIItemSlot ui = Instantiate(itemSlotPrefab, slotParent).GetComponent<UIItemSlot>();
            ui.InitSlotUI(PlayerManager.Instance.inventory.itemSlots[i]);
        }
    }
}
