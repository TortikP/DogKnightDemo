using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    public List<ItemInstance> inventoryItems = new List<ItemInstance>();
    public List<Item> items = new List<Item>();
    public InventoryUI inventoryUI;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ManageInventory();
        DropItem();
    }
    public void AddItem(ItemInstance item)
    {
        item.id = inventoryItems.Count;
        print(item.id + " " + item.item.itemName);
        inventoryItems.Add(item);
        items.Add(item.item);
        inventoryUI.AddItem(inventoryItems[inventoryItems.Count-1]);
    }
    public void DropItem()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (inventoryItems.Count > 0)
            {
                print(inventoryItems[0].id);
                inventoryUI.Remove(inventoryItems[0].id);
                GameObject thisItem = inventoryItems[0].item.prefab;
                print(inventoryItems[0].condition);
                SpawnDroppedItem(thisItem);
            }
            print("try spawn");
        }
    }

    public void SpawnDroppedItem(GameObject myItem)
    {
        GameObject spawnedObject = Instantiate(myItem, GetComponent<DogKnight>().charCenter.position + GetComponent<DogKnight>().charCenter.forward*3, Quaternion.RotateTowards(Quaternion.identity, Quaternion.AngleAxis(90.0f,transform.right), 90.0f));
        print(spawnedObject.GetComponent<Collider>().isTrigger);
        if (spawnedObject.GetComponent<Collect>())
        {
            spawnedObject.GetComponent<Collect>().condition = inventoryItems[0].condition;
            spawnedObject.GetComponent<Collect>().cost = inventoryItems[0].cost;
            spawnedObject.GetComponent<Collect>().FixColliders();
            print(spawnedObject.GetComponent<Collect>().condition);
        }
        spawnedObject.GetComponent<Rigidbody>().velocity = transform.forward * 10f + transform.up * 5f;
        inventoryItems.Remove(inventoryItems[0]);
        items.Remove(items[0]);

    }

    public void ManageInventory()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(inventoryUI.gameObject.activeSelf)
            {
                inventoryUI.gameObject.SetActive(false);
            }
            else
            {
                inventoryUI.gameObject.SetActive(true);
            }
        }
    }
}
