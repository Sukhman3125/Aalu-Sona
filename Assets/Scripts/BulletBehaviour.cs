using DG.Tweening;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private void Start()
    {
        var rb = GetComponent<Rigidbody2D>();

        rb.AddForce(GameManager.Instance.bulletSpeed * transform.forward/rb.mass, ForceMode2D.Impulse);
        DOVirtual.DelayedCall(GameManager.Instance.bulletLifeTime, () => Destroy(gameObject));
    }
}
