using UnityEngine;

[CreateAssetMenu(fileName = "ColorEffect", menuName = "Effects/ColorEffect")]
public class ColorEffectSO : EffectSO
{
    [SerializeField] private Color color;
    [SerializeField] private bool randomColor;

    public override void ApplyEffect(GameObject target)
    {
        if (target.TryGetComponent<Renderer>(out var renderer))
        {
            if (randomColor)
                renderer.material.color = Random.ColorHSV();
            else
                renderer.material.color = color;
        }
    }
}