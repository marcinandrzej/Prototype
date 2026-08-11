using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour, IInputManager
{  
    private EInputContext _activeContext = EInputContext.Inactive;
    private List<IInputController> _activeControllers = new List<IInputController>();

    public void ChangeContext(EInputContext inputContext) 
    {
        _activeContext = inputContext;

        foreach (IInputController controller in _activeControllers)
            controller.SetContext(_activeContext);
    }

    public void RegisterController(IInputController inputController) 
    {
        if (_activeControllers.Contains(inputController))
            return;

        _activeControllers.Add(inputController);
        inputController.SetContext(_activeContext);
    }

    public void UnregisterController(IInputController inputController)
    {
        if (!_activeControllers.Contains(inputController))
            return;

        inputController.SetContext(EInputContext.Inactive);
        _activeControllers.Remove(inputController);
    }
}
