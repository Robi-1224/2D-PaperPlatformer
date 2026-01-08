using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Settings")]
    [SerializeField] Vector3 offSet;
    private Transform _playerTransform;
    void Awake()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        FollowPlayer();
    }
    private void FollowPlayer()
    {
      transform.SetPositionAndRotation(new Vector3(_playerTransform.position.x,_playerTransform.position.y,transform.position.z) + offSet,Quaternion.identity);
    }

   
}
 