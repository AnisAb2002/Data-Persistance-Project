using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    public string playerName;
    public int highScore;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadingData();
    }

    void Start()
    {
        Debug.Log(Application.persistentDataPath);
    }


    void Update()
    {
        
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int hScore;
    }

    public void SavingData()
    {

        SaveData data = new SaveData();
        data.name = playerName;
        data.hScore = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText( Application.persistentDataPath + "/GameDatasaving.json", json);

    }
    public void LoadingData()
    {
        string path = Application.persistentDataPath + "/GameDatasaving.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.hScore;
            playerName = data.name;
        }
    }

}

