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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && _grounded)
        {
            _grounded = false;
            _rb.AddForceY(transform.position.y *_jumpForce, ForceMode2D.Impulse);
            Debug.Log("jump");
        }
    }

    public void Movement(InputAction.CallbackContext context)
    {
        if (context.performed && _grounded && !_dead)
        {

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
