using System;

[Serializable]
public struct InputContextData
{
    public EInputContext context;
    public string actionMapNameOrId;
    public int priority;
}