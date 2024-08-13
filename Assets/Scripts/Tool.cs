using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tool", menuName = "Tool")]
public class Tool : ScriptableObject
{
    public EffectSO effect;

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

        effect.ApplyEffect(target);

        Debug.Log($"Used {name} on {target.name}");
    }
}
