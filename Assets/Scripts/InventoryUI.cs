using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform inventoryGrid;
    public InventorySlot inventorySlot;
    public void AddItem(ItemInstance item)
    {
        InventorySlot slot = Instantiate(inventorySlot, inventoryGrid);
        slot.Item = item;
        
    }
    public void Remove(int itemId)
    {
        foreach(InventorySlot item in GetComponentsInChildren<InventorySlot>())
        {
            if (item != null)
            {
                if (item.Item.id == itemId)
                {
                    Destroy(item.gameObject);
                }
            }
        }
    }
}
