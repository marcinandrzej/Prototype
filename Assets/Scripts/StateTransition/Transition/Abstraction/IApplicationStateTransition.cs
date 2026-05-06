using System.Collections;

public interface IApplicationStateTransition
{
    public IEnumerator Execute();
}
