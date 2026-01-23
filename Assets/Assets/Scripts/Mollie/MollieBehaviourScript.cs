using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class MollieBehaviourScript : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float grabRange;

    [Header("Component")]
    [SerializeField] LayerMask interactableLayer;
    private RaycastHit2D _ray;
    void Awake()
    {
        
    }

   public void GrabObject(InputAction.CallbackContext context)
   {
        _ray = Physics2D.Raycast(transform.position, Vector2.right, grabRange, interactableLayer);
        if (context.performed &&_ray != false)
        {
            Debug.Log(_ray.transform.name);
        }
   }
}
