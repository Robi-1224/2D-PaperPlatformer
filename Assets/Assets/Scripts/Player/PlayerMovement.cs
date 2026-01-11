using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private bool _grounded = false;
    private bool _dead = false;

    [Header("Components")]
    [SerializeField] LayerMask _groundLayer;
    private Rigidbody2D _rb;

    [Header("Variables")]
    private Vector2 moveInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementBehaviour();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && _grounded)
        {
            _grounded = false;
            _rb.AddForce(new Vector2(0,transform.position.y) *_jumpForce,ForceMode2D.Impulse);
        }
    }

    private void MovementBehaviour()
    {
        transform.Translate(moveInput.x * _speed * Time.deltaTime,0 ,0);
    }

    public void MovementInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveInput = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            moveInput.x = 0;
        }
    }
    private void CollisionBehaviourCheck(Collider2D col)
    {
        if ((_groundLayer.value & (1<< col.gameObject.layer ))!=0)
        {
            _grounded = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CollisionBehaviourCheck(collision.collider);
       
    }
}
