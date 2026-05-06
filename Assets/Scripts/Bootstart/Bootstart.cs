using UnityEngine;

public class Bootstart : MonoBehaviour
{
    [Tooltip("Reference to IApplicationStateManager")]
    [SerializeField] private Object applicationStateManagerObject = null;

    [Tooltip("Reference to initial IApplicationStateTransition")]
    [SerializeField] private Object applicationStateTransitionObject = null;

    private void OnValidate()
    {
        if (applicationStateManagerObject != null && !(applicationStateManagerObject is IApplicationStateManager))
            applicationStateManagerObject = null;

        if (applicationStateTransitionObject != null && !(applicationStateTransitionObject is IApplicationStateTransition))
            applicationStateTransitionObject = null;
    }

    private void Start()
    {
        IApplicationStateManager manager = applicationStateManagerObject as IApplicationStateManager;
        IApplicationStateTransition transition = applicationStateTransitionObject as IApplicationStateTransition;
        manager.ExecuteStateTransition(transition);
        Destroy(gameObject);
    }
}
