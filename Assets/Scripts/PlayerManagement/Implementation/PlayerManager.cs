using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour, IPlayerManager
{
    [SerializeField] private PlayerInputManager playerInputManager;

    private List<PlayerInput> _players = new List<PlayerInput>();

    public PlayerInput FirstPlayer => _players[0];

    public List<PlayerInput> Players => _players;
    
    private void OnEnable()
    {
        playerInputManager.onPlayerJoined += PlayerInputManager_onPlayerJoined;
        playerInputManager.onPlayerLeft += PlayerInputManager_onPlayerLeft;
    }

    private void OnDisable()
    {
        playerInputManager.onPlayerJoined -= PlayerInputManager_onPlayerJoined;
        playerInputManager.onPlayerLeft -= PlayerInputManager_onPlayerLeft;
    }

    public void EnablePlayerJoining() => playerInputManager.EnableJoining();

    public void DisablePlayerJoining() => playerInputManager.DisableJoining();

    public bool IsFirstPlayer(PlayerInput player) 
    {
        if (!_players.Contains(player))
            return false;

        int playerIndex = _players.IndexOf(player);

        return playerIndex == 0;
    }

    private void PlayerInputManager_onPlayerJoined(PlayerInput player)
    {
        if(!_players.Contains(player))
            _players.Add(player);
    }

    private void PlayerInputManager_onPlayerLeft(PlayerInput player)
    {
        if (_players.Contains(player))
            _players.Remove(player);
    }
}
