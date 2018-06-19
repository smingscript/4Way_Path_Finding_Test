
using UnityEngine;

public class MainCanvasManager : MonoBehaviour
{
    public static MainCanvasManager Instance;
    
    [SerializeField] private LobbyCanvas _lobbyCanvas;

    public LobbyCanvas LobbyCanvas
    {
        get { return _lobbyCanvas; }
    }

    private void Awake()
    {
        Instance = this;
    }

    public void OnClickMakeRoom()
    {
        GameObject roomSettingPanel = transform.Find("RoomSettingPanel").gameObject;
        GameObject lobbyUI = transform.Find("Lobby").gameObject;
        roomSettingPanel.SetActive(true);
        lobbyUI.SetActive(false);
    }
}