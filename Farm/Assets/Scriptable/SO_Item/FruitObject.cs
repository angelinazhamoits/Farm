using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Fruit", menuName = "Inventory System/Item/Fruit")]

public class FruitObject : ItemObject
{
 private void Awake()
 {
  type = ItemType.Fruit;
 }
}
