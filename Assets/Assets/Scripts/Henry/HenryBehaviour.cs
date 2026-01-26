using Unity.VisualScripting;
using UnityEngine;

public class HenryBehaviour : MonoBehaviour
{
    private PlayerMovement _movement;
    private Rigidbody2D _rb;
    private Collider2D playerCollider;
    private Collider2D objectBlocker;
    private int _interactableLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _movement = GetComponent<PlayerMovement>();
        playerCollider = GetComponent<Collider2D>();
        objectBlocker = GetComponentInChildren<Collider2D>();
        _interactableLayer = LayerMask.NameToLayer("Interactable");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InteractableIgnoreCollision(Collider2D collision)
    {
        Vector2 dir = (collision.transform.position-transform.position ).normalized;
        if (Vector2.Dot(_movement.movementDir, dir) > 0f)
        {
            _movement.TurnInputOnOrOff(false);
            _rb.WakeUp();
        }
        else
        {
            _movement.TurnInputOnOrOff(true);
            _rb.Sleep();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _interactableLayer)
        {
            InteractableIgnoreCollision(collision);
        }
    }
}
