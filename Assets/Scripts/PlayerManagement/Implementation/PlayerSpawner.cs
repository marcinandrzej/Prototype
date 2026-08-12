using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : IPlayerSpawner
{
    [SerializeField] private PlayerInputListenerBase playerPrefab;
    [SerializeField] private Transform playersParent;
    [SerializeField] private Transform spawnPoint;

    private Dictionary<PlayerInputController, PlayerInputListenerBase> _listenersDict = new Dictionary<PlayerInputController, PlayerInputListenerBase>();

    public void SpawnPlayer(PlayerInputController playerInputController)
    {
        PlayerInputListenerBase player = Object.Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation, playersParent);
        player.SetPlayerInput(playerInputController);
        player.StartListeningInput();
        _listenersDict.Add(playerInputController, player);
    }

    public void SpawnPlayers(List<PlayerInputController> playerInputControllerList)
    {
        foreach (PlayerInputController playerInputController in playerInputControllerList)
            SpawnPlayer(playerInputController);
    }

    public void DestroyPlayer(PlayerInputController playerInputController)
    {
        if (_listenersDict.TryGetValue(playerInputController, out PlayerInputListenerBase player)) 
        {
            player.StopListeningInput();
            _listenersDict.Remove(playerInputController);
            GameObject.Destroy(player.gameObject);
        }
    }

    public void DestroyAllPlayers()
    {
        foreach (PlayerInputListenerBase player in _listenersDict.Values)
        {
            player.StopListeningInput();
            GameObject.Destroy(player.gameObject);
        }

        _listenersDict.Clear();
    }
}
