using UnityEngine;

public class ScaleOverTime : MonoBehaviour
{
    [SerializeField] private Transform transformToScale = null;
    [Header("Axis settings")]
    [SerializeField] private bool useAxisX = false;
    [SerializeField] private bool useAxisY = false;
    [SerializeField] private bool useAxisZ = false;
    [Header("Time settings")]
    [SerializeField] private bool useUnscaledTime = false;
    [SerializeField] private AnimationCurve animationCurve;

    private float _currentTime = 0.0f;
    private Vector3 _baseVector = Vector3.one;

    private void Awake()
    {
        _baseVector = transformToScale.localScale;
    }

    private void OnEnable()
    {
        transformToScale.localScale = GetScaleOverTime(_currentTime);     
    }

    private void Update()
    {
        _currentTime += useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
        transformToScale.localScale = GetScaleOverTime(_currentTime);
    }

    private Vector3 GetScaleOverTime(float time) 
    {
        float curveValue = animationCurve.Evaluate(time);
        Vector3 newScale = _baseVector;

        if (useAxisX)
            newScale.x = curveValue;

        if (useAxisY)
            newScale.y = curveValue;

        if (useAxisZ)
            newScale.z = curveValue;

        return newScale;
    }
}
