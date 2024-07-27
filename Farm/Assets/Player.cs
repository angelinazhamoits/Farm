using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField] private InventoryObject _inventory;

   private void OnTriggerEnter(Collider other)
   {
      var item = other.GetComponent<GroundItem>();
      if (item)
      {
         if (item.item._isRipe)
         {
            Item invItem = new Item(item.item);
            _inventory.AddItem(invItem, 1);
            Destroy(other.gameObject);
         } 
         else
         {
            Debug.Log("Урожай не созрел");
         }
      }
     
   }
}
