using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONSave : MonoBehaviour
{
    private GameData gameData;

    private string path = "";
    // Start is called before the first frame update
    void Start()
    {
        SetPath();
        CreateGameData();
    }

    private void CreateGameData()
    {
        if (File.Exists(path))
        {
            LoadData();
            return;
        }
        //gameData = new GameData("¼Ú«§¹Ç", 100f, 20f, 15);
        gameData = new GameData();
    }

    private void SetPath()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "Datas/saveData.json";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SaveData();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            LoadData();
        }
    }

    public void SaveData()
    {
        string savePath = path;

        Debug.Log($"Àx¦sÀÉ®×©ó¡G{savePath}");

        gameData.DataUpdate();
        string json = JsonUtility.ToJson(gameData);
        Debug.LogWarning(json);

        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
    }
    public void LoadData()
    {
        using StreamReader reader = new StreamReader(path);
        string json = reader.ReadToEnd();

        GameData data = JsonUtility.FromJson<GameData>(json);

        //gameData = new GameData(data.name, data.hp, data.mp, data.lv);
        gameData = new GameData();

        Debug.LogWarning(data.ToString());
    }
}
