using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "RotateEffect", menuName = "Effects/RotateEffect")]
public class RotateEffectSO : EffectSO
{
    [SerializeField] private float duration;

    public override void ApplyEffect(GameObject target)
    {
        target.transform.DORotate(new Vector3(0, 360, 0), duration, RotateMode.FastBeyond360).SetEase(Ease.InOutBounce);
    }
}
