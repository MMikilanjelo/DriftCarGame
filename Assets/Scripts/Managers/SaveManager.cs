using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveManager 
{
    
    public static PlayerGameData Load()
    {
        if(!File.Exists(GetSavingPath()))
        {
            PlayerGameData _emptyPlayerGameData = new PlayerGameData();
            Save(_emptyPlayerGameData);
            return _emptyPlayerGameData;
        }
        else{
            BinaryFormatter _binaryFormatter = new BinaryFormatter();
            FileStream _file = File.Open(GetSavingPath() , FileMode.Open);
            PlayerGameData _playerData = _binaryFormatter.Deserialize(_file) as PlayerGameData;
            _file.Close();
            return _playerData;
        }
    
    }
    public static void Save(PlayerGameData _playerData)
    {
        BinaryFormatter _binaryFormatter = new BinaryFormatter();
        FileStream _file = File.Create(GetSavingPath());
        _binaryFormatter.Serialize(_file , _playerData);
        _file.Close();
    }
    private static string GetSavingPath()
    {
        return Path.Combine( Application.persistentDataPath + "/playerInfo.dat");
    }

}

