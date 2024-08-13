using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "SizeEffect", menuName = "Effects/SizeEffect")]
public class SizeEffectSO : EffectSO
{
    [SerializeField] private Vector3 sizeChange;

    public override void ApplyEffect(GameObject target)
    {
        target.transform.DOScale(target.transform.localScale + sizeChange, 1f).SetEase(Ease.InElastic);
    }
}
