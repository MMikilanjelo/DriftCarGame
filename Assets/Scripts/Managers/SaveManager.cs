using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public int _currency;
    private readonly string _savePath ="/playerInfo.dat";
    public static SaveManager _saveMangerInstance {get;set;}
    private void Awake()
    {
        if(_saveMangerInstance != null && _saveMangerInstance != this)
        {
            Destroy(gameObject);
        }
        else{
            _saveMangerInstance = this;
        }
        
        DontDestroyOnLoad(gameObject);
        Load();
    }

    private void Start()
    {
        RegisterCurrencyEvents();
    }
    private void RegisterCurrencyEvents()
    {
        EventManager<EventTypes.GameEvents , int>.RegisterEvent(EventTypes.GameEvents.BeginDrifting , (int value)=>
        {
            _currency += value;
        });
    }
    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + _savePath))
        {
            BinaryFormatter _binaryFormatter = new BinaryFormatter();
            FileStream _file = File.Open(Application.persistentDataPath + _savePath , FileMode.Open);
            PlayerDataStorage _playerData = (PlayerDataStorage) _binaryFormatter.Deserialize(_file);
            ExtractData(_playerData);
            
        }
        
    }
    private void ExtractData(PlayerDataStorage _playerData)
    {
        _currency = _playerData._currency;
    }
    public void Save()
    {
        BinaryFormatter _binaryFormatter = new BinaryFormatter();
        FileStream _file = File.Create(Application.persistentDataPath + _savePath);
        PlayerDataStorage _playerData = new PlayerDataStorage
        {
            _currency = this._currency
        };
        _binaryFormatter.Serialize(_file , _playerData);
        _file.Close();
    }

}
[Serializable]
public class PlayerDataStorage
{
    public int _currency;
}
