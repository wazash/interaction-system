using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private Color defaultColor, activeColor;


    public void ClearSlot()
    {
        text.text = string.Empty;
        text.color = defaultColor;
    }

    public void SetSlot(char key)
    {
        text.text = key.ToString();
        text.color = defaultColor;
    }

    public void SetActive(bool active)
    {
        text.color = active ? activeColor : defaultColor;
    }
}
