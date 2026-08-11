using System.Collections;

public class WaitForServiceRegisteredTransitionActionGeneric<ServiceInterfaceT> : IApplicationStateTransitionAction where ServiceInterfaceT : IService
{
    public IEnumerator Execute()
    {
        while(!ServiceManager.Instance.IsServiceRegistered<ServiceInterfaceT>())
            yield return null;

        yield return null;
    }
}
