using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Inventory", menuName = "Inventory System / Inventory")]

public class InventoryObject : ScriptableObject
{
    public Inventory Container;
    public ItemDatabaseObject _Database;

    public void MoveItem(InventorySlot item1, InventorySlot item2)
    {
        InventorySlot temp = new InventorySlot(item2.ID, item2.Item, item2.Amount);
        item2.UpdateSlot(item1.ID, item1.Item, item1.Amount);
        item1.UpdateSlot(temp.ID, temp.Item, temp.Amount);
    }

    public void RemoveItem(Item item)
    {
        for (int i = 0; i < Container.Items.Length; i++)
        {
            if (Container.Items[i].Item == item)
            {
                Container.Items[i].UpdateSlot(-1, null, 0);
            }
        }
    }

    public void AddItem(Item item, int amount)
    {
        for (int i = 0; i < Container.Items.Length; i++)
        {
            if (Container.Items[i].ID == item.Id)
            {
                Container.Items[i].AddAmount(amount); 
                return;
            }
           
        }

        SetEmptySlot(item, amount);
    }

    public InventorySlot SetEmptySlot(Item item, int amount)
    {
        for (int i = 0; i < Container.Items.Length; i++)
        {
            if (Container.Items[i].ID <= -1)
            {
                Container.Items[i].UpdateSlot(item.Id, item, amount);
                return Container.Items[i];
            }


        }

        return null;
    }
}
[System.Serializable]
public class Inventory
{
    public InventorySlot[] Items = new InventorySlot[28];
    
}

[System.Serializable]
public class InventorySlot
{
    public int ID = -1;
    public Item Item;
    public int Amount;

    public InventorySlot ()
    {
        ID = -1;
        Item = null;
        Amount = 0;
    }

    public InventorySlot(int id, Item item, int amount)
    {
        ID = id;
        Item = item;
        Amount = amount;
    }

    public void UpdateSlot(int id, Item item, int amount)
    {
        ID = id;
        Item = item;
        Amount = amount;
    }

    public void AddAmount(int value)
    {
        Amount += value;
    }
    
}
