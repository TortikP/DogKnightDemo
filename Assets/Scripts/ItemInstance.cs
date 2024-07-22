using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInstance
{
    public int id;
    public Item item;
    public int condition;
    public int cost;
    public int amount;
    public bool isEmpty => item == null;

    public ItemInstance(Item item, int condition, int cost)
    {
        this.item = item;
        this.condition = condition;
        this.cost = cost*condition/100;
    }
}
