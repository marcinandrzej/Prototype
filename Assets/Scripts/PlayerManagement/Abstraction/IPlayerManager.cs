using System.Collections.Generic;

public interface IPlayerManager : IService
{
    public PlayerInputController FirstPlayer { get; }

    public List<PlayerInputController> Players { get; }

    public void EnablePlayerJoining();
    
    public void DisablePlayerJoining();
}
