using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class PlayerInputSolver
{
    [SerializeField] private InputContextData[] contextDataArray;
    [SerializeField] private string defaultContextNameOrId = "None";

    private Dictionary<EInputContext, int> _priorityDict = null;
    private Dictionary<EInputContext, string> _actionMapDict = null;

    public void CreateDictionaries()
    {
        _priorityDict = new Dictionary<EInputContext, int>();
        _actionMapDict = new Dictionary<EInputContext, string>();

        foreach (InputContextData data in contextDataArray)
        {
            _priorityDict.Add(data.context, data.priority);
            _actionMapDict.Add(data.context, data.actionMapNameOrId);
        }
    }

    public string ResolveInputActionMapNameOrId(Dictionary<EInputContext, HashSet<object>> requestedContextDict)
    {
        IEnumerable<EInputContext> validContext = requestedContextDict.Where(pair => pair.Value != null && pair.Value.Count > 0).Select(pair => pair.Key);

        if (validContext.Count() > 0)
        {
            IOrderedEnumerable<EInputContext> orderedValidContext = validContext.OrderByDescending(context => _priorityDict.TryGetValue(context, out int priority) ? priority : 0);
            EInputContext context = orderedValidContext.First();

            if (_actionMapDict.TryGetValue(context, out string actionMapNameOrId))
                return actionMapNameOrId;
        }

        return defaultContextNameOrId;
    }
}
