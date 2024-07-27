using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    private void Start()
    {
        CreateSlots();
    }

    private void Update()
    {
            
        UpdateSlots();
    }

    private MouseItem MouseItem = new MouseItem();
    [SerializeField] private GameObject _inventoryCellPrefab;
    [SerializeField] private InventoryObject _inventory;

    [SerializeField] private int X_Start;
    [SerializeField] private int Y_Start;

    [SerializeField] private int  X_SpaceBetweenItem;
     [SerializeField] private int Y_SpaceBetweenItem;
     [SerializeField] private int NumberOfCollumn;
   private Dictionary<GameObject, InventorySlot> _itemsDisplayed;

   public void CreateSlots()
   {
       _itemsDisplayed = new Dictionary<GameObject, InventorySlot>();
       for (int i = 0; i < _inventory.Container.Items.Length; i++)
       {
           var obj = Instantiate(_inventoryCellPrefab, Vector3.zero, quaternion.identity, transform);
           obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
           AddEvent(obj, EventTriggerType.PointerClick, delegate { OnEnter(obj);});
           AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj);});
           
           AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragBegin(obj);});  
           AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj);}); 
           AddEvent(obj, EventTriggerType.Drag, delegate { OnDragged(obj);});
           
           _itemsDisplayed.Add(obj, _inventory.Container.Items[i]);
       }
   }

   public void UpdateSlots()
   {
       foreach (KeyValuePair<GameObject, InventorySlot> invSlot in _itemsDisplayed)
       {
           if (invSlot.Value.ID >= 0)
           {
               invSlot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = _inventory
                   ._Database
                   .GetItem[invSlot.Value.Item.Id].uiDisplay;
               invSlot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color =
                   new Color(1, 1, 1, 1);
               invSlot.Key.GetComponentInChildren<TextMeshProUGUI>().text = invSlot.Value.Amount == 1
                   ? ""
                   : invSlot
                       .Value.Amount.ToString("N0");
           }
           else
           {
               invSlot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
               invSlot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color =
                   new Color(1, 1, 1, 0);
               invSlot.Key.GetComponentInChildren<TextMeshProUGUI>().text = "";
           }
       }
   }
   
   private void OnDragged(GameObject obj)
   {
       if (MouseItem.obj!= null)
       {
           MouseItem.obj.GetComponent<RectTransform>().position = Input.mousePosition;
       }
   }

   private void OnDragEnd(GameObject obj)
   {
       if (MouseItem.hoverObj)
       {
         _inventory.MoveItem(_itemsDisplayed[obj], _itemsDisplayed[MouseItem.hoverObj]);
       }
       else
       {
           _inventory.RemoveItem(_itemsDisplayed[obj].Item);
       }
       Destroy(MouseItem.obj);
       MouseItem.item = null;
   }

   private void OnDragBegin(GameObject obj)
   {
       var mouseObject = new GameObject();
       var rt = mouseObject.AddComponent<RectTransform>();
       rt.sizeDelta = new Vector2(50, 50);
       mouseObject.transform.SetParent(transform.parent);
       if (_itemsDisplayed[obj].ID >= 0)
       {
           var img = mouseObject.AddComponent<Image>();
           img.sprite = _inventory._Database.GetItem[_itemsDisplayed[obj].ID].uiDisplay;
           img.raycastTarget = false;

       }

       MouseItem.obj = mouseObject;
       MouseItem.item = _itemsDisplayed[obj];
   }

   private void OnExit(GameObject obj)
   {
       MouseItem.hoverObj = null;
       MouseItem.hoverItem = null;
   }

   private void OnEnter(GameObject obj)
   {
       MouseItem.hoverObj = obj;
       if (_itemsDisplayed.ContainsKey(obj))
       {
           MouseItem.hoverItem = _itemsDisplayed[obj];
       }
   }
   private Vector3 GetPosition (int i)
   {
       return new Vector3(X_Start + (X_SpaceBetweenItem * (i % NumberOfCollumn)), Y_Start + (-Y_SpaceBetweenItem * (i /
           NumberOfCollumn)), 0f);

   }
   
   
private void AddEvent (GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
{
    EventTrigger trigger = obj.GetComponent<EventTrigger>();
    var eventTrigger = new EventTrigger.Entry();
    eventTrigger.eventID = type;
    eventTrigger.callback.AddListener(action);
    trigger.triggers.Add(eventTrigger);
}
}

public class MouseItem
{
    public GameObject obj;
    public GameObject hoverObj;
    public InventorySlot hoverItem;
    public InventorySlot item;
}
