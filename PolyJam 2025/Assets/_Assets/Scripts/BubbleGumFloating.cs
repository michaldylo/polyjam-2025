using UnityEngine;
using UnityEngine.InputSystem;

public class BubbleGumFloating : MonoBehaviour
{
    private InputAction _floatAction;
    private Rigidbody2D _rb;
    [SerializeField] private float _floatSpeed = 80f;
    [Range(0, 0.3f)][SerializeField] private float _movementSmoothing = 0.05f;
    private Vector3 _velocity = Vector3.zero;
    private Inventory _inventory;

    private void Awake()
    {
        _floatAction = InputSystem.actions.FindAction("Float");
        _rb = GetComponent<Rigidbody2D>();
        _inventory = GetComponent<Inventory>();
    }

    private void Update()
    {
        if (_floatAction.IsPressed() && _inventory.HasItem("BubbleGum"))
        {
            Float(_floatSpeed * Time.deltaTime);
        }
    }

    private void Float(float speed)
    {
        // _rb.AddForce(new Vector2(0f, force));
        Vector3 targetVelocity = new Vector2(_rb.linearVelocity.x, speed * 10f);
        _rb.linearVelocity = Vector3.SmoothDamp(_rb.linearVelocity, targetVelocity, ref _velocity, _movementSmoothing);
    }
}
