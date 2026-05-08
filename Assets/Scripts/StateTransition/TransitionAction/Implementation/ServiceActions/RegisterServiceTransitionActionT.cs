using System.Collections;

public class RegisterServiceTransitionActionT<ServiceInterfaceT> : IApplicationStateTransitionAction where ServiceInterfaceT : IService
{
    private ServiceInterfaceT _service;

    public RegisterServiceTransitionActionT(ServiceInterfaceT service) 
    {
        _service = service;
    }

    public IEnumerator Execute()
    {
        ServiceManager.Instance.RegisterService(_service);
        
        yield return null;
    }
}