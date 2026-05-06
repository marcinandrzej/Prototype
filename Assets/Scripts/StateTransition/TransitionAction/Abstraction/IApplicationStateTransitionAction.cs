using System.Collections;

public interface IApplicationStateTransitionAction
{
    public IEnumerator Execute();
}