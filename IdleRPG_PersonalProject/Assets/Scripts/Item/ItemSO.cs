using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/New Item")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;

    public int itemPrice;
}
