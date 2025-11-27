using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothTime = 0.15f;   

    private Vector2 velocity = Vector3.zero;
    private float cameraOffsetZ = 20f;


    private void Awake()
    {
        cameraOffsetZ = transform.position.z;
    }

    void LateUpdate()
    {

        Vector2 targetPos = Movement.Instance.transform.position;

        transform.position = Vector2.SmoothDamp(
            transform.position,
            targetPos,
            ref velocity,
            smoothTime
        );
        transform.position = new Vector3(transform.position.x,transform.position.y,cameraOffsetZ);
    }
}
