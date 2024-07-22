using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public int stackSize;
    [TextArea]
    public string description;
    public int condition;
    public int cost;
    public Sprite icon;
    public GameObject prefab;
}
