using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private ItemInstance item;
    public ItemInstance Item {
        set 
        {
            item = value;
            itemImage.sprite = item.item.icon;
            itemText.text = item.item.itemName;
            itemCondition.text = item.condition.ToString();
        }
        get
        {
            return item;
        } 
    }
    [SerializeField]
    private Image itemImage;
    [SerializeField]
    private TMP_Text itemText;
    [SerializeField]
    private TMP_Text itemCondition;

}
