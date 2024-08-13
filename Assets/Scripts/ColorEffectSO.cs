using DG.Tweening;
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
            {
                Color random = Random.ColorHSV();
                renderer.material.DOColor(random, 1f).SetEase(Ease.Linear);

            }
            else
                renderer.material.DOColor(color, 1f).SetEase(Ease.Linear);
        }
    }
}