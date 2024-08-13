using UnityEngine;

[CreateAssetMenu(fileName = "ColorEffect", menuName = "Effects/ColorEffect")]
public class ColorEffectSO : EffectSO
{
    [SerializeField] private Color color;

    public override void ApplyEffect(GameObject target)
    {
        if (target.TryGetComponent<Renderer>(out var renderer))
        {
            renderer.material.color = color;
        }
    }
}