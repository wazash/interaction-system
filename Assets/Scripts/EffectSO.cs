using UnityEngine;

public abstract class EffectSO : ScriptableObject
{
    public char Key => name[0];
    public abstract void ApplyEffect(GameObject target);
}