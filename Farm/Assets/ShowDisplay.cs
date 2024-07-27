using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShowDisplay : MonoBehaviour
{
   [SerializeField] private GameObject _playerDisplay;
   private bool _playerDisplayIsOpened = false;

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Q))
         if (_playerDisplayIsOpened)
         {
            Unshow();
         }
         else
         {
            Show();
         }
   }

   private void Show()
   {
            _playerDisplay.SetActive(true);
            _playerDisplayIsOpened = true;
   }

   private void Unshow()
   {
      _playerDisplay.SetActive(false);
      _playerDisplayIsOpened = false;
   }
}

