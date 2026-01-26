using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Settings")]
    public int speed;
    public bool canMove = true;
    [SerializeField] private float _jumpForce;
    [SerializeField] private bool _grounded = false;
    private bool _dead = false;

    [Header("Components")]
    [SerializeField] LayerMask _groundLayer;
    private Rigidbody2D _rb;
    private SpriteRenderer _sprite;

    [Header("Variables")]
    private Vector2 moveInput;
    public Vector2 movementDir;
    private int _henryJumpCount = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementBehaviour();
       
    }

    public void TurnInputOnOrOff(bool input)
    {
        canMove = input;
        Debug.Log(canMove);
    }

    public void HenryDoubleJump(InputAction.CallbackContext context)
    {
        if (context.performed && _henryJumpCount != 0)
        {
            _rb.linearVelocityY = 0;
            _rb.AddForce(_jumpForce * Vector2.up, ForceMode2D.Impulse);
            _grounded = false;
            _henryJumpCount--;
            
        }

    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && _grounded)
        {
            _rb.AddForce(_jumpForce * Vector2.up,ForceMode2D.Impulse);
            _grounded = false;
           
        }
    }

    private void FlipSprite()
    {
         switch (moveInput.x)
         {
            case 1: _sprite.flipX = false; break;
            case -1: _sprite.flipX = true; break;
         }
    }

    private void MovementBehaviour()
    {
        if (moveInput.x != 0 && canMove)
        {
            transform.Translate(moveInput.x * speed * Time.deltaTime, 0, 0);
            FlipSprite();
        }
    }

    public void MovementInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveInput = context.ReadValue<Vector2>();
            movementDir = moveInput;
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
            _henryJumpCount = 2;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CollisionBehaviourCheck(collision.collider);
    }
}
