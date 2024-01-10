using System.Collections.Generic;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

public class GameRepository : IGameRepository
{
    private const string SAVE_KEY = "gameState";
    private Dictionary<string, string> _gameState = new();

    public T GetData<T>()
    {
        var keyName = typeof(T).Name;
        var serializedData = _gameState[keyName];
        var decryptedData = AESEncryptionService.Decrypt(serializedData);
        var data = JsonConvert.DeserializeObject<T>(decryptedData);
        return data;
    }

    public bool TryGetData<T>(out T value)
    {
        var keyName = typeof(T).Name;

        if (_gameState.TryGetValue(keyName, out var serializedData))
        {
            var decryptedData = AESEncryptionService.Decrypt(serializedData);
            value = JsonConvert.DeserializeObject<T>(decryptedData);
            return true;
        }

        value = default;
        return false;
    }

    public void SetData<T>(T value)
    {
        var keyName = typeof(T).Name;
        var serializedData = JsonConvert.SerializeObject(value);
        var encryptedData = AESEncryptionService.Encrypt(serializedData);
        _gameState[keyName] = encryptedData;
    }

    public void LoadState()
    {
        if (PlayerPrefs.HasKey(SAVE_KEY))
        {
            var data = PlayerPrefs.GetString(SAVE_KEY);
            _gameState = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
        }
    }

    public void SaveState()
    {
        var data = JsonConvert.SerializeObject(_gameState);
        PlayerPrefs.SetString(SAVE_KEY, data);
    }
}