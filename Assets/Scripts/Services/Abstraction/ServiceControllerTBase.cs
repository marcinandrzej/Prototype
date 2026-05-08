using UnityEngine;

public class ServiceControllerTBase<ServiceInterfaceT, ServiceClassT> : ServiceControllerBase where ServiceClassT : ServiceInterfaceT where ServiceInterfaceT : IService
{
    [SerializeField] private ServiceClassT service;

    public override void RegisterService() => ServiceManager.Instance.RegisterService<ServiceInterfaceT>(service);

    public override void UnregisterService() => ServiceManager.Instance.UnregisterService<ServiceInterfaceT>();
}