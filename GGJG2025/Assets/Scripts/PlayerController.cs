using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb2D;
    public PlayerInputActions playerControls;
    public float playerSpeed;
    public float jumpPower;

    private Vector2 movementInput;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();

        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnVertMovement(InputValue inputValue)
    {
        movementInput.x = inputValue.Get<float>() * playerSpeed;
        print(movementInput.x);
    }
    private void OnJump(InputValue inputValue)
    {
        print(IsGrounded());
        print(inputValue.isPressed);
        if (inputValue.isPressed && IsGrounded())
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, jumpPower);
        }
    }
    private void FixedUpdate()
    {
        if (movementInput != Vector2.zero)
        {
            _rb2D.AddForce(movementInput);
        }
    }

    bool IsGrounded()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y - 1f);
        return Physics2D.Raycast(pos, -Vector3.up, 0.2f);
    }
}
