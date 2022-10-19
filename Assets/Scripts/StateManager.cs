using UnityEngine;


public class StateManager : MonoBehaviour
{
    public static StateManager Instance;
    private string playerName;
    private int bestScore;

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

    public void SetBestScore(int score)
    {
        bestScore = score;
    }

    public int GetBestScore()
    {
        return bestScore;
    }

    public void SetPlayerName(string player)
    {
        playerName = player;
    }

    public string GetPlayerName()
    {
        return playerName;
    }
}
