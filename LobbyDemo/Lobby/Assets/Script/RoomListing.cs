using UnityEngine;
using UnityEngine.UI;

public class RoomListing : MonoBehaviour
{
    [SerializeField] 
    private Text _roomNameText;
    public Text RoomNameText
    {
        get { return _roomNameText; }
    }

    [SerializeField]
    private Text _roomPlayersNumberText;
    public Text RoomPlayersNumberText
    {
        get { return _roomPlayersNumberText; }
    }

    public string RoomName { get; private set; }
    public string PlayersNumber { get; private set; }

    //public bool Updated { get; set; }

    public void SetRoomNameText(string text)
    {
        RoomName = text;
        RoomNameText.text = RoomName;
    }

    public void SetNumberOfOccupants(RoomInfo room)
    {
        PlayersNumber = string.Format("{0} / {1}", room.PlayerCount, room.MaxPlayers);
        RoomPlayersNumberText.text = PlayersNumber;
    }
}
