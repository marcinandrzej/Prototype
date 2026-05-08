using System.Collections;

public class ServiceControllerUnregisterTransitionAction : IApplicationStateTransitionAction
{
    private ServiceControllerBase _serviceController;

    public ServiceControllerUnregisterTransitionAction(ServiceControllerBase serviceController)
    {
        _serviceController = serviceController;
    }

    public IEnumerator Execute()
    {
        _serviceController.UnregisterService();

        yield return null;
    }
}
