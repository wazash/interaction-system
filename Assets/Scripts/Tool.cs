using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    public List<EffectSO> effects = new();

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

        Debug.Log($"Used {this.gameObject.name} on {target.name}");
    }
}
