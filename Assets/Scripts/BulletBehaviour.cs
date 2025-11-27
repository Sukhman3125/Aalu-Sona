using DG.Tweening;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private void Start()
    {
        var rb = GetComponent<Rigidbody>();

        rb.AddForce(GameManager.Instance.bulletSpeed * transform.forward, ForceMode.VelocityChange);
        DOVirtual.DelayedCall(GameManager.Instance.bulletLifeTime, () => Destroy(gameObject));
    }
}
