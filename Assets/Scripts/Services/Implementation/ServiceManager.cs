using System;
using System.Collections.Generic;
using UnityEngine;

public class ServiceManager : MonoBehaviour
{
    private Dictionary<Type, IService> _services = new Dictionary<Type, IService>();

    public static ServiceManager Instance { get; private set; }

    private void Awake()
    {
        _services.Clear();
        Instance = this;
    }

    public void RegisterService<ServiceInterfaceT>(ServiceInterfaceT service) where ServiceInterfaceT : IService
    {
        Type type = typeof(ServiceInterfaceT);

        if (!_services.ContainsKey(type))
            _services.Add(type, service);
        else
            Debug.LogError($"Service of type {type.Name} is already registered");
    }

    public void UnregisterService<ServiceInterfaceT>() where ServiceInterfaceT : IService
    {
        Type type = typeof(ServiceInterfaceT);

        if (_services.ContainsKey(type))
            _services.Remove(type);
        else
            Debug.LogError($"Service of type {type.Name} is not registered");
    }

    public ServiceInterfaceT Get<ServiceInterfaceT>() where ServiceInterfaceT : IService
    {
        Type type = typeof(ServiceInterfaceT);

        if (_services.TryGetValue(type, out var service))
            return (ServiceInterfaceT)service;
        else
            Debug.LogError($"Service of type {type.Name} is not registered");
        
        return default;
    }

    public bool IsServiceRegistered<ServiceInterfaceT>() where ServiceInterfaceT : IService
    {
        Type type = typeof(ServiceInterfaceT);

        return _services.TryGetValue(type, out var service);
    }
}
