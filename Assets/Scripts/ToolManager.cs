using UnityEngine;

public class ToolManager : MonoBehaviour
{
    [SerializeField] private Tool[] tools;

    public int CurrentToolIndex { get; private set; } = 0;

    public void SwitchTool(int index)
    {
        CurrentToolIndex = Mathf.Clamp(index, 0, tools.Length - 1);

        Debug.Log($"Switched to tool {CurrentToolIndex}");
    }

    public void UseTool(GameObject target)
    {
        tools[CurrentToolIndex].Use(target);
    }
}
