using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb2D;
    public PlayerInputActions playerControls;
    public float playerSpeed;

    private Vector2 movementInput;
    private Vector2 aimInput;

    public Transform Arm;

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
    private void OnAiming(InputValue inputValue)
    {
        aimInput = inputValue.Get<Vector2>() * 10;
        print(aimInput);
    }

    private void FixedUpdate()
    {
        if (movementInput != Vector2.zero)
        {
            _rb2D.AddForce(movementInput);
        }

        if (aimInput != Vector2.zero)
        {
            float angle = Vector2.Angle(Vector2.zero, aimInput);
            var eulers = Quaternion.Euler(0, angle, 0);
            Arm.transform.rotation = eulers;
        }
    }

}
