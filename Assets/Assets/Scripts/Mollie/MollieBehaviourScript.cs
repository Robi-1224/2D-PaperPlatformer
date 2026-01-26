using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class MollieBehaviourScript : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float grabRange;
    [SerializeField] private int throwForce;

    [Header("Components")]
    [SerializeField] private LayerMask interactableLayer;
    private RaycastHit2D _ray;
    private PlayerMovement _movement;

    [Header("Grabbing Components")]
    [SerializeField] private Transform _grabTrans;
    private Transform heldTrans;
    private Rigidbody2D heldRb;

    [Header("Variables")]
    private Vector2 _dir;
    private bool _grabbing = false;
    void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
    }

    public void GrabObject(InputAction.CallbackContext context)
    {
        // checks if a player is facing left or right, then checks if anything is infront of it if it is then pick it up and slow its speed by half, if it is already holding something put it down.
        if (_movement != null && context.performed)
        {
            Vector2 pos = new Vector2(transform.position.x, transform.position.y + 1);

            switch (_movement.movementDir.x)
            {
                case 1: _dir = Vector2.right; break;
                case -1: _dir = Vector2.left; break;
            }
            
            _ray = Physics2D.Raycast(pos,_dir, grabRange, interactableLayer);
            if (_ray.collider != null && !_grabbing)
            {
                heldTrans = _ray.transform;
                heldRb = _ray.rigidbody;
                heldRb.simulated = false;
                heldTrans.parent = _grabTrans;
                heldTrans.position = _grabTrans.position;
                _grabbing = true;
                _movement.speed = _movement.speed / 2;

            } else if (_grabbing) 
            {
                _grabTrans.transform.DetachChildren();
                heldRb.simulated = true;
                heldRb.AddForce(_dir * throwForce, ForceMode2D.Impulse);
                _grabbing = false;
                _movement.speed = _movement.speed * 2;
            }
        }
    }
   
}
