using System;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    [SerializeField] private List<Tool> tools;

    public int CurrentToolIndex { get; private set; } = 0;

    public event Action<int> OnToolChanged;

    public void SwitchTool(int index)
    {
        CurrentToolIndex = (index + tools.Count) % tools.Count;
        OnToolChanged?.Invoke(CurrentToolIndex);

        Debug.Log($"Switched to tool {tools[CurrentToolIndex].name}");
    }

    public void UseTool(GameObject target)
    {
        tools[CurrentToolIndex].Use(target);
    }

    public Tool GetTool(int index)
    {
        return tools[index];
    }

    public List<Tool> GetTools()
    {
        return tools;
    }
}
