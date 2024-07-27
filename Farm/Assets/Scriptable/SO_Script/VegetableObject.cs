using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Vegetable", menuName = "Inventory System/Item/Vegetable")]
public class VegetableObject : ItemObject
{
    private void Awake()
    {
        type = ItemType.Vegetable;
    }
}
