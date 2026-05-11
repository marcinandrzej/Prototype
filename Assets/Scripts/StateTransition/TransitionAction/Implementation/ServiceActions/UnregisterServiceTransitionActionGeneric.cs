using System.Collections;

public class UnregisterServiceTransitionActionGeneric<ServiceInterfaceT> : IApplicationStateTransitionAction where ServiceInterfaceT : IService
{
    public IEnumerator Execute()
    {
        ServiceManager.Instance.UnregisterService<ServiceInterfaceT>();

        yield return null;
    }
}