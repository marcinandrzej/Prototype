using System.Collections;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    private IEnumerator Start()
    {
        //Wait for State Transition to End
        IApplicationStateManager applicationStateManager = ServiceManager.Instance.Get<IApplicationStateManager>();

        while (applicationStateManager.IsInTransition)
            yield return null;

        //Spawn Main Menu Input Controller
        // TO DO

        //Play Enter Animation
        //TO DO

        //Activate MainMenu Panel
        //TO DO
    }
}
