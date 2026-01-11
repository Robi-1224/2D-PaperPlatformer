using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class coopManager : MonoBehaviour
{
    [SerializeField] PlayerInput _player1Input;
    [SerializeField] PlayerInput _player2Input;

    public void PlayerDisconnectBehaviour()
    {
       Debug.Log("disconnected please reconnect");
       Time.timeScale =0;
    }

   
    public void PlayerReconnected()
    {
        Time.timeScale = 1f;
        Debug.Log("player reconnected");
    }
}
