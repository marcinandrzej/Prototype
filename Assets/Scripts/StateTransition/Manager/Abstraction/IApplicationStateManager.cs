public interface IApplicationStateManager : IService
{
    public bool IsInTransition { get; }

    public void ExecuteStateTransition(IApplicationStateTransition transition);
}