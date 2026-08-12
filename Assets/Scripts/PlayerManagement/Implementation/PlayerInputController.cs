using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerInputSolver playerInputSolver;

    private Dictionary<EInputContext, HashSet<object>> _registeredInputRequestDict = new Dictionary<EInputContext, HashSet<object>>(); 

    public PlayerInput PlayerInput => playerInput;

    private void Awake()
    {
        playerInputSolver.CreateDictionaries();
    }

    public void RegisterInputContext(EInputContext context, object source)
    {
        ValidateContextRequests();

        if (!_registeredInputRequestDict.ContainsKey(context))
        {
            _registeredInputRequestDict.Add(context, new HashSet<object>());
        }

        if(_registeredInputRequestDict[context].Add(source))
        {
            string actionMapNameOrId = playerInputSolver.ResolveInputActionMapNameOrId(_registeredInputRequestDict);
            PlayerInput.SwitchCurrentActionMap(actionMapNameOrId);
        }        
    }

    public void UnregisterInputContext(EInputContext context, object source) 
    {
        ValidateContextRequests();

        if (_registeredInputRequestDict.ContainsKey(context) && _registeredInputRequestDict[context].Remove(source))
        {
            string actionMapNameOrId = playerInputSolver.ResolveInputActionMapNameOrId(_registeredInputRequestDict);
            PlayerInput.SwitchCurrentActionMap(actionMapNameOrId);
        }
    }

    public void ClearInputContext() 
    {
        _registeredInputRequestDict.Clear();
        string actionMapNameOrId = playerInputSolver.ResolveInputActionMapNameOrId(_registeredInputRequestDict);
        PlayerInput.SwitchCurrentActionMap(actionMapNameOrId);
    }

    private void ValidateContextRequests() 
    {
        foreach (EInputContext key in _registeredInputRequestDict.Keys)
        {
            if (_registeredInputRequestDict[key] != null)
                _registeredInputRequestDict[key].Remove(null);
        }
    }
}
