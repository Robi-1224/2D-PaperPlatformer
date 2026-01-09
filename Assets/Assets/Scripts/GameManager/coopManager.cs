using UnityEngine;

public class coopManager : MonoBehaviour
{
    [SerializeField] Transform _spawnPoint;
    [SerializeField] GameObject _player2Transform;
    private void Awake()
    {
       
    }
    
    public void PlayerJoinBehaviour()
    {
        if (_player2Transform != null)
        {
            Debug.Log("player 2 joined");
            _player2Transform.transform.position = _spawnPoint.position;
        }
    }

}
