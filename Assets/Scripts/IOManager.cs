using UnityEngine;
using System.IO;

public class IOManager : MonoBehaviour
{
    public static IOManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    class PlayerData
    {
        public string playerName;
        public int bestScore;
    }

    public void SavePlayerData()
    {
        PlayerData data = new PlayerData();
        data.playerName = StateManager.Instance.GetPlayerName();
        data.bestScore =StateManager.Instance.GetBestScore();
        string json = JsonUtility.ToJson(data);

        string saveFilePath = Application.persistentDataPath + $"/playerdata.json";
        File.WriteAllText(saveFilePath, json);
    }

    public void LoadPlayerData()
    {
        string saveFilePath = Application.persistentDataPath + $"/playerdata.json";

        if (File.Exists(saveFilePath))
        {
            string jsonData = File.ReadAllText(saveFilePath);

            PlayerData playerData = JsonUtility.FromJson<PlayerData>(jsonData);
            StateManager.Instance.SetPlayerName(playerData.playerName);
            StateManager.Instance.SetBestScore(playerData.bestScore);

        }
    }

}
