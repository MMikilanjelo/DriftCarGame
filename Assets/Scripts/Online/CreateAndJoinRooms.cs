using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;
public class CreateAndJoinRooms : MonoBehaviourPunCallbacks 
{
    public InputField _createInputField;
    public InputField _joinInputField;
    [SerializeField] Button _createRoomButton;
    [SerializeField] Button _joinRoomButton;
    [SerializeField] Object _onlineLevelScene;
    public void Awake()
    {
        SetUpButtons();
    }
    private void SetUpButtons()
    {
        _createRoomButton.onClick.RemoveAllListeners();
        _createRoomButton.onClick.AddListener(()=> CreatRoom());
        
        _joinRoomButton.onClick.RemoveAllListeners();
        _joinRoomButton.onClick.AddListener(()=> JoinRoom());
    }
    private void CreatRoom()
    {
        if(_createInputField.text.IsNullOrEmpty()) return;
        Debug.Log(_createInputField.text);
        PhotonNetwork.CreateRoom(_createInputField.text);
    }
    private void JoinRoom()
    {
        if(_createInputField.text.IsNullOrEmpty()) return;
        PhotonNetwork.JoinRoom(_joinInputField.text);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(_onlineLevelScene.name);
    }
    
}
