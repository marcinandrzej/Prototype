using UnityEngine;

public abstract class PlayerInputListenerBase : MonoBehaviour
{
    protected PlayerInputController _playerInput = null;

    public void SetPlayerInput(PlayerInputController playerInput) 
    {
        _playerInput = playerInput;
    }

    public abstract void StartListeningInput();

    public abstract void StopListeningInput();
}