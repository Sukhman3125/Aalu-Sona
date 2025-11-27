using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;           
    public float smoothTime = 0.15f;   
    public Vector3 offset;             

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetPos = target.position + offset;

        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPos,
            ref velocity,
            smoothTime
        );
    }
}
