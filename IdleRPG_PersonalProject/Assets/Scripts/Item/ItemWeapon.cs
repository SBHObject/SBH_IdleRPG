using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemWeapon
{
    public ItemWeapon(ItemSO data)
    {
        ItemData = data;
        itemUpgradeCount = 0;
    }

    public ItemSO ItemData { get; private set; }

    [SerializeField] public int itemUpgradeCount;

    public int ItemAttack  => ItemData.itemDamage + (ItemData.itemDamagePerUp * itemUpgradeCount);
    public int UpgradeCost => ItemData.UpgradePrice + (ItemData.UpgradePricePerUp * itemUpgradeCount);
    
}
