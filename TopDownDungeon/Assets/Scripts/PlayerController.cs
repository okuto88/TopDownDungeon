
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    private void Awake()
    {
        // Rigidbody2Dを取得
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // 新しいInput Systemからキーボード入力を取得
        Keyboard keyboard = Keyboard.current;

        if (keyboard == null)
        {
            movement = Vector2.zero;
            return;
        }

        float moveX = 0f;
        float moveY = 0f;

        if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed)
        {
            moveX = -1f;
        }
        else if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed)
        {
            moveX = 1f;
        }

        if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed)
        {
            moveY = -1f;
        }
        else if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed)
        {
            moveY = 1f;
        }

        // 斜め移動の速度を調整
        movement = new Vector2(moveX, moveY).normalized;
    }

    private void FixedUpdate()
    {
        // Rigidbody2Dを使って移動
        rb.linearVelocity = movement * moveSpeed;
    }
}