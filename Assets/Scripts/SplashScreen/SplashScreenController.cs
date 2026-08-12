using System.Collections;
using UnityEngine;

public class SplashScreenController : MonoBehaviour
{
    [Header("UI settings")]
    [SerializeField] private GameObject anyButtonTextGO;
    [Header("Transition settings")]
    [SerializeField] private string splashScreenSceneName = "SplashScreenScene";
    [SerializeField] private string mainMenuSceneName = "MainMenuScene";
    [Header("Animation settings")]
    [SerializeField] private Animator animator;
    [SerializeField] private int animationLayerIndex = 0;
    [SerializeField] private float animationDelayS = 2f;
    [SerializeField] private string showTrigger = "Show";
    [SerializeField] private string hideTrigger = "Hide";
    [SerializeField] private string idleStateName = "Idle";
    [SerializeField] private string hiddenStateName = "Hidden";

    private int _idleStateShortNameHash;
    private int _hiddenStateShortNameHash;

    private void Awake()
    {
        _idleStateShortNameHash = Animator.StringToHash(idleStateName);
        _hiddenStateShortNameHash = Animator.StringToHash(hiddenStateName);
    }

    private IEnumerator Start()
    {
        //Wait a bit
        yield return new WaitForSecondsRealtime(animationDelayS);

        //Play Enter Animation
        animator.SetTrigger(showTrigger);
        
        yield return new WaitUntil( () =>
            !animator.IsInTransition(animationLayerIndex) &&
            animator.GetCurrentAnimatorStateInfo(animationLayerIndex).shortNameHash == _idleStateShortNameHash);

        //Wait for State Transition to End
        IApplicationStateManager applicationStateManager = ServiceManager.Instance.Get<IApplicationStateManager>();

        while (applicationStateManager.IsInTransition)
            yield return null;

        //Turn on join notification
        anyButtonTextGO.SetActive(true);

        //Wait For Player To Join
        IPlayerManager playerManager = ServiceManager.Instance.Get<IPlayerManager>();
        playerManager.EnablePlayerJoining();
        
        while (playerManager.Players.Count <= 0)
            yield return null;

        playerManager.DisablePlayerJoining();

        //Turn off join notification
        anyButtonTextGO.SetActive(false);

        //Play Exit Animation
        animator.SetTrigger(hideTrigger);

        yield return new WaitUntil(() =>
            !animator.IsInTransition(animationLayerIndex) &&
            animator.GetCurrentAnimatorStateInfo(animationLayerIndex).shortNameHash == _hiddenStateShortNameHash);

        //Wait a bit
        yield return new WaitForSecondsRealtime(animationDelayS);

        //Trigger Main Menu State Transition
        SplashScreenToMainMenuTransition transition = new SplashScreenToMainMenuTransition(splashScreenSceneName, mainMenuSceneName);
        applicationStateManager.ExecuteStateTransition(transition);
    }
}
