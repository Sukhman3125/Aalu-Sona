using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : Singleton<Movement>
{

    public float walkSpeed = 6f;
    public float jumpPower = 7f;
    public float gravity = 10f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // --------------------------
        // 1. WORLD-SPACE INPUT (ISO)
        // --------------------------
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputZ = Input.GetAxisRaw("Vertical");

        Vector3 inputDir = new Vector3(inputX, 0f, inputZ);

        // movement speed
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        // Always world-space, NEVER using transform.forward/right
        Vector3 horizontalMove = inputDir.normalized * walkSpeed;

        // --------------------------
        // 2. JUMP + GRAVITY
        // --------------------------
        float verticalVel = moveDirection.y;

        if (Input.GetButtonDown("Jump") && characterController.isGrounded)
            verticalVel = jumpPower;

        if (!characterController.isGrounded)
            verticalVel -= gravity * Time.deltaTime;
        else if (verticalVel < 0)
            verticalVel = -1f; // small grounding force

        // final movement vector
        moveDirection = new Vector3(horizontalMove.x, verticalVel, horizontalMove.z);

        // --------------------------
        // 3. MOVE CHARACTER
        // --------------------------
        characterController.Move(moveDirection * Time.deltaTime);

        // --------------------------
        // 4. ROTATE PLAYER (ISO)
        // --------------------------
        if (inputDir.sqrMagnitude > 0.1f)
        {
            Quaternion targetRot = Quaternion.LookRotation(inputDir, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 10f * Time.deltaTime);
        }
    }
}
