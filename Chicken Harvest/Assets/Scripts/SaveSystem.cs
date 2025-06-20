using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    private string savePath;

    private void Awake()
    {
        savePath = Application.persistentDataPath + "/save.json";
        //Debug.Log("Save Path: " + savePath);
    }

    public void SaveGame()
    {
        SaveData data = GameManager.Instance.GetSaveData();
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
        Debug.Log("Game Saved to " + savePath);
    }

    public void LoadGame()
    {
        
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            GameManager.Instance.LoadFromSave(data);
            Debug.Log("Game Loaded");
        }
        else
        {
            Debug.LogWarning("No save file found.");
        }
    }
}