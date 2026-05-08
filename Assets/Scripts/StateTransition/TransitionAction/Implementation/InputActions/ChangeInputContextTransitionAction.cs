using System.Collections;

public class ChangeInputContextTransitionAction : IApplicationStateTransitionAction
{
    private EInputContext _inputContext;

    public ChangeInputContextTransitionAction(EInputContext inputContext) 
    {
        _inputContext = inputContext;
    }

    public IEnumerator Execute()
    {
        IInputManager inputManager = ServiceManager.Instance.Get<IInputManager>();
        inputManager.ChangeContext(_inputContext);

        yield return null;
    }
}
