using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
   Fruit,
   Vegetable,
   RootCrop,
   Cereals,
   Tools
}
public abstract class ItemObject : ScriptableObject
{
   public int Id;
   public Sprite uiDisplay;
   public ItemType type;
   [TextArea(15, 20)] public string description;
   public GameObject _currentStage;
   public GameObject _ripeing_stage_1;
   public GameObject _ripeing_stage_2;
   public GameObject _ripeing_stage_3;
   public GameObject _riped;

   public bool _isRipe;

  
   public Item CreateItem()

   {
      Item newItem = new Item(this);
      return newItem;
   }
   
}

[System.Serializable]
public class Item
{
  
   public string Name;
   public int Id;

   public Item(ItemObject item)
   {
      Name = item.name;
      Id = item.Id;
      
   }

  
   
}
