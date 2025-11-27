using DG.Tweening;
using UnityEngine;

public class PeriodicMotion : MonoBehaviour
{
    private void Start()
    {
        transform.DOScale(GameManager.Instance.ammo_maxScale, GameManager.Instance.ammo_cycleTime)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }
}
