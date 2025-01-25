using Unity.VisualScripting;
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
        Vector2 input = inputValue.Get<Vector2>();
        if (input != Vector2.zero)
        {
            aimInput = input;
        }
        else
        {
            aimInput = Vector2.right;
        }
        print(aimInput);
    }
    private void FixedUpdate()
    {
        if (movementInput != Vector2.zero)
        {
            _rb2D.AddForce(movementInput);
        }
        Quaternion newquat = Quaternion.LookRotation(aimInput, Vector2.up);
        Arm.transform.rotation = Quaternion.Lerp(Arm.transform.rotation, newquat, Time.deltaTime);
    }
}
