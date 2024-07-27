using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGamePlayerPref : MonoBehaviour
{
    private int _intSave;
    private float _floatSave;
    private string _stringSave = "";


    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 125, 50), "Изменить integer"))
        {
            _intSave++;
        }
        if (GUI.Button(new Rect(0, 100, 125, 50), "Изменить float"))
        {
            _floatSave++;
        }

        _stringSave = GUI.TextField(new Rect(0, 200, 125, 25), _stringSave, 15);
        GUI.Label(new Rect(375, 0, 125, 50), "Значение integer" + _intSave);
        GUI.Label(new Rect(375, 100, 125, 50), "Значение float" + _floatSave);
        GUI.Label(new Rect(375, 200, 125, 50), "Значение string" + _stringSave);

        if (GUI.Button(new Rect(750, 0 , 125,50),"Сохранить"))
        {
            SaveGame();
        }
        if (GUI.Button(new Rect(750, 100 , 125,50),"Сохранить"))
        {
            LoadGame();
        }
        if (GUI.Button(new Rect(750, 200 , 125,50),"Сохранить"))
        {
            ResetData();
        }
    }

    private void SaveGame()
    {
        PlayerPrefs.SetInt("Save integer", _intSave);
        PlayerPrefs.SetFloat("Save float", _floatSave);
        PlayerPrefs.SetString("Save string", _stringSave);
        PlayerPrefs.Save();
        Debug.Log("SAVE");
    }

    private void LoadGame()
    {
        if (PlayerPrefs.HasKey("Save integer"))
        {
            _intSave = PlayerPrefs.GetInt("Save integer");
            _floatSave = PlayerPrefs.GetFloat("Save float");
            _stringSave = PlayerPrefs.GetString("Save string");
            Debug.Log("Loaded");
        }
        else
        {
            Debug.LogError("Данные потеряны");
        }
    }

    private void ResetData()
    {
        PlayerPrefs.DeleteAll();
        _intSave = 0;
        _floatSave = 0;
        _stringSave = "";
        Debug.Log("Очищено");
    }
}
