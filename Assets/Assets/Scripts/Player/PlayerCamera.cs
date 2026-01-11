using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Settings")]
    [SerializeField] Vector3 _camOffSet;
    [Header("Components")]
    private Camera _camera;
    private Transform _playerTransform;
    private Transform _player2Trans;
    [Header("Settings")]
    [SerializeField] float _minScreenAspectSize;
    [SerializeField] float _offSet;
    [SerializeField] float zoomOutAmount;
    [SerializeField] float zoomOutSpeed;
    [SerializeField] float zoomInAmount;

    void Awake()
    {
        _camera = Camera.main;
        _player2Trans = GameObject.Find("Player 2").transform;
        _playerTransform = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        FollowPlayer();
        KeepPlayersOnScreamExtend();
    }
    private void FollowPlayer()
    {
      transform.SetPositionAndRotation(new Vector3(_playerTransform.position.x,_playerTransform.position.y,transform.position.z) + _camOffSet,Quaternion.identity);
    }

    private void KeepPlayersOnScreamExtend()
    {
        float viewPort = _camera.orthographicSize * _camera.aspect;
        float rightSide = _camera.transform.position.x + viewPort;
        float leftSide = _camera.transform.position.x - viewPort;
       

        if (_player2Trans.position.x > rightSide - _offSet || _player2Trans.position.x < leftSide + _offSet)
        {
            _camera.orthographicSize += zoomOutAmount * Time.deltaTime * zoomOutSpeed;
        }
        else if (viewPort > _minScreenAspectSize)
        {
            _camera.orthographicSize -= zoomInAmount * Time.deltaTime;
        }

    }
}
 