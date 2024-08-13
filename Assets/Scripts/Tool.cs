using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tool", menuName = "Tool")]
public class Tool : ScriptableObject
{
    public string SlotKey;
    public List<EffectSO> effects;

    public void Use(GameObject target)
    {
        if (target == null)
        {
            return;
        }

        if (target.CompareTag("Target") == false)
        {
            return;
        }

        foreach (var effect in effects)
        {
            effect.ApplyEffect(target);
        }

        Debug.Log($"Used {name} on {target.name}");
    }
}
