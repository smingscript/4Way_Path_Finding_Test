using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoom : MonoBehaviour
{
    #region outlets

    [SerializeField] 
    private Text _roomName;

    private Text RoomName
    {
        get { return _roomName; }
    }
    #endregion

    #region fields

    #endregion

    #region messages

    #endregion

    #region methods
    public void OnClick_CreateRoom()
    {
        GameObject roomSettingPanel = transform.Find("RoomSettingPanel").gameObject;
        GameObject lobbyUI = transform.Find("Lobby").gameObject;
        roomSettingPanel.SetActive(false);
        lobbyUI.SetActive(true);

        RoomOptions roomOptions = new RoomOptions() { IsVisible =  true, IsOpen = true, MaxPlayers = 4 };
        
        if (PhotonNetwork.CreateRoom(RoomName.text, roomOptions, TypedLobby.Default))
        {
            print("Create Room Successfully sent.");
        }
        else
        {
            print("Create Room failed to sent.");
        }
    }

    private void OnPhotonCreateRoomFailed(object[] codeAndMessage)
    {
        print("Create Room Failed: " + codeAndMessage[1]);
    }

    private void OnCreatedRoom()
    {
        print("Room created successfully");
        PhotonNetwork.LoadLevel("Room For 2");
    }
    #endregion
}
