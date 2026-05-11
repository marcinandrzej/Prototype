using System.Collections;

public class RegisterServiceTransitionActionGeneric<ServiceInterfaceT> : IApplicationStateTransitionAction where ServiceInterfaceT : IService
{
    private ServiceInterfaceT _service;

    public RegisterServiceTransitionActionGeneric(ServiceInterfaceT service) 
    {
        _service = service;
    }

    public IEnumerator Execute()
    {
        ServiceManager.Instance.RegisterService(_service);
        
        yield return null;
    }
}