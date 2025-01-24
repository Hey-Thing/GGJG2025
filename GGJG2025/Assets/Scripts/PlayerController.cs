using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb2D;
    public PlayerInputActions playerControls;

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
        Vector2 direction = inputValue.Get<Vector2>();
        print(direction);

        _rb2D.AddForce(direction);
    }
}
