using System.Collections;

public class ServiceControllerRegisterTransitionAction : IApplicationStateTransitionAction
{
    private ServiceControllerBase _serviceController;

    public ServiceControllerRegisterTransitionAction(ServiceControllerBase serviceController)
    {
        _serviceController = serviceController;
    }

    public IEnumerator Execute()
    {
        _serviceController.RegisterService();

        yield return null;
    }
}
