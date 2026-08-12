using System.Collections.Generic;

public interface IPlayerSpawner : IService
{
    public void DestroyAllPlayers();
    public void DestroyPlayer(PlayerInputController playerInputController);
    public void SpawnPlayer(PlayerInputController playerInputController);
    public void SpawnPlayers(List<PlayerInputController> playerInputControllerList);
}
