using UnityEngine;

public class Movement : Singleton<Movement>
{

    public float walkSpeed = 6f;
    public float rotationSpeed = 10f;

    private Vector2 moveDirection = Vector2.zero;

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector2 inputDir = new Vector2(inputX,inputY);

        Vector2 horizontalMove = inputDir.normalized * walkSpeed;

        moveDirection = new Vector2(horizontalMove.x,horizontalMove.y);

        transform.Translate(moveDirection * Time.deltaTime,Space.World);

        if (inputDir.sqrMagnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(inputY, inputX) * Mathf.Rad2Deg - 90f;
            Quaternion targetRot = Quaternion.Euler(0f, 0f, targetAngle);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRot,
                rotationSpeed * Time.deltaTime
            );
        }
    }
}
