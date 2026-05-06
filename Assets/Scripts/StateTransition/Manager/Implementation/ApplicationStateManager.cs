using System.Collections;
using UnityEngine;

public class ApplicationStateManager : MonoBehaviour, IApplicationStateManager
{
    private Coroutine _currentTransition = null;

    public bool IsInTransition => _currentTransition != null;

    public void ExecuteStateTransition(IApplicationStateTransition transition) 
    {
        if (IsInTransition) 
        {
            Debug.LogError("ApplicationManager is already executing transition");
            
            return;
        }

        _currentTransition = StartCoroutine(ExecuteStateTransitionCoroutine(transition));
    }

    private IEnumerator ExecuteStateTransitionCoroutine(IApplicationStateTransition transition) 
    {
        yield return transition.Execute();

        _currentTransition = null;
    }
}
