using System.Collections.Generic;
using UnityEngine.InputSystem;

public interface IPlayerManager : IService
{
    public PlayerInput FirstPlayer { get; }

    public List<PlayerInput> Players { get; }

    public void EnablePlayerJoining();
    
    public void DisablePlayerJoining();
}
