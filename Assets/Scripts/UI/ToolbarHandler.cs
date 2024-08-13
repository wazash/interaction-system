using System.Collections.Generic;
using UnityEngine;

public class ToolbarHandler : MonoBehaviour
{
    [SerializeField] private List<Slot> slots;
    [SerializeField] private ToolManager toolManager;

    [SerializeField] private GameObject slotObject;

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
        ClearToolbar();

        InstantiateSlots();
    }

    private void ClearToolbar()
    {
        foreach (var slot in slots)
        {
            Destroy(slot.gameObject);
        }
    }

    private void InstantiateSlots()
    {
        for (int i = 0; i < toolManager.GetTools().Count; i++)
        {
            var slot = Instantiate(slotObject, transform).GetComponent<Slot>();
            slot.SetSlot(toolManager.GetTool(i).SlotKey);
            slots.Add(slot);
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
