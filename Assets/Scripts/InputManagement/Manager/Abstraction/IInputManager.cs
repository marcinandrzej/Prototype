public interface IInputManager : IService
{
    public void ChangeContext(EInputContext inputContext);

    public void RegisterController(IInputController inputController);

    public void UnregisterController(IInputController inputController);
}
