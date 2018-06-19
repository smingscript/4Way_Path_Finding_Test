using UnityEngine;


public class LobbyNetwork : MonoBehaviour
{
    #region outlets
    
    #endregion

    #region fields
    
    #endregion

    #region messages

    private void Start()
    {
        print("Connecting to Server..");
        PhotonNetwork.ConnectUsingSettings("1");
    }

    private void OnConnectedToMaster()
    {
        print("Connected to master");
        PhotonNetwork.playerName = PlayerNetwork.Instance.PlayerName;
        
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    private void OnJoinedLobby()
    {
        print("joined Lobby");
    }

    #endregion	

    #region methods
    
    #endregion
}
