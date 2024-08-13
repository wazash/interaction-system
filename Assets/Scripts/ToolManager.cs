using System;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    [SerializeField] private Tool[] tools;

    public int CurrentToolIndex { get; private set; } = 0;

    public event Action<int> OnToolChanged;

    public void SwitchTool(int index)
    {
        CurrentToolIndex = Mathf.Clamp(index, 0, tools.Length - 1);
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
}
