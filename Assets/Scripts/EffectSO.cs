using UnityEngine;

public abstract class EffectSO : ScriptableObject
{
    public abstract void ApplyEffect(GameObject target);
}