using UnityEngine;

[CreateAssetMenu(fileName = "SizeEffect", menuName = "Effects/SizeEffect")]
public class SizeEffectSO : EffectSO
{
    [SerializeField] private Vector3 sizeChange;

    public override void ApplyEffect(GameObject target)
    {
        target.transform.localScale += sizeChange;
    }
}
