using UnityEngine;

public class ToolbarHandler : MonoBehaviour
{
    [SerializeField] private Slot[] slots;
    [SerializeField] private ToolManager toolManager;

    private void Start()
    {
        PopulateToolbar();

        HandleToolChanged(toolManager.CurrentToolIndex);

        toolManager.OnToolChanged += HandleToolChanged;
    }

    private void OnDisable()
    {
        toolManager.OnToolChanged -= HandleToolChanged;
    }

    public void PopulateToolbar()
    {
        foreach (var slot in slots)
        {
            slot.ClearSlot();
        }

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].SetSlot(toolManager.GetTool(i).effect.Key);
        }
    }

    private void HandleToolChanged(int index)
    {
        foreach (var slot in slots)
        {
            slot.SetActive(false);
        }

        slots[index].SetActive(true);
    }
}
