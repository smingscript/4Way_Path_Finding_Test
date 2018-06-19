using UnityEngine;


public class LobbyCanvas : MonoBehaviour
{
    [SerializeField] private RoomLayoutGroup _roomLayoutGroup;

    public RoomLayoutGroup RoomLayoutGroup
    {
        get { return _roomLayoutGroup; }
    }

    public void OnClickJoinRoom(string roomName)
    {
        
    }

    
}
