using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 move;
    private Animator animator;
    [SerializeField] private float moveSpeed = 8f;
    private bool isRunning = false;
    private float currentSpeed;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        currentSpeed = moveSpeed;
    }

    void Update()
    {
        HandleInput();
        MovePlayer();
    }

    private void HandleInput()
    {
        // Kiểm tra nếu Shift được nhấn
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
            currentSpeed = moveSpeed * 2; // Tăng tốc độ lên gấp đôi khi chạy
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
            currentSpeed = moveSpeed; // Trở lại tốc độ ban đầu khi dừng chạy
        }

        if (Input.GetMouseButton(0))
        {
            animator.SetTrigger("isAttacking");
        }
    }

    private void MovePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.05f);
            transform.Translate(movement * Time.deltaTime * currentSpeed, Space.World);
        }

        // Cập nhật tốc độ cho animator
        float speed = movement.magnitude * (isRunning ? 2f : 1f); // Tính toán tốc độ hiện tại
        animator.SetFloat("Speed", speed);
    }
}