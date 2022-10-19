using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour

{
    public InputField PlayerName;
    private string playerName;

    private void Awake()
    {
        IOManager.Instance.LoadPlayerData();
        
    }

    private void Start()
    {
        playerName = StateManager.Instance.GetPlayerName();
        if (!string.IsNullOrEmpty(playerName))
        {
            PlayerName.text = playerName;
        }
    }
    public void PlayerNameChanged()
    {
        string player = PlayerName.text.ToString();
        StateManager.Instance.SetPlayerName(player);
        IOManager.Instance.SavePlayerData();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
