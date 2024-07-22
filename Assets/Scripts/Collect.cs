using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public Item item;
    public int condition;
    public int cost;
    public virtual void Start()
    {
        condition = item.condition;
        cost = item.cost;
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Inventory>().AddItem(new ItemInstance(item, condition, item.cost));
            Destroy(gameObject);
        }

    }

    public virtual void OnCollisionEnter(Collision collider)
    {
        foreach(Collider coll in GetComponents<Collider>())
        {
            coll.enabled = true;
        }
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
    public virtual void FixColliders()
    {

    }
}
