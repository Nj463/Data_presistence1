using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    const string gameInfoFileName = "savedata.json";

    public Record record;

    private string filePath;
    public string currentUsername;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadRecords();
    }
    private void Start()
    {
        filePath = Application.persistentDataPath + "/" + gameInfoFileName;
    }

    [System.Serializable]
    public class Record
    {
        public string username;
        public int score;
    }

    public void SaveRecords(string username, int score)
    {
        record.score = score;
        record.username = username;
        File.WriteAllText(filePath, JsonUtility.ToJson(record));
    }
    public void LoadRecords()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            Record data = JsonUtility.FromJson<Record>(json);
            record = data;
        }

    }
}