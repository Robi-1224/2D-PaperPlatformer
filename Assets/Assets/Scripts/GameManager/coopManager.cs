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

    public void OnPlayerSelect()
    {
        if(Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            SwitchToGamepad(_player2Input);
        }else if(Keyboard.current!=null && Keyboard.current.enterKey.wasPressedThisFrame)
        {
            SwitchToKeyboard(_player1Input);
            Debug.Log("Keyboard");
        }
    }

    private void SwitchToKeyboard(PlayerInput input)
    {
        input.SwitchCurrentControlScheme(
            "Keyboard&Mouse",
            Keyboard.current
        );
    }

    private void SwitchToGamepad(PlayerInput input)
    {
        input.SwitchCurrentControlScheme(
            "Gamepad",
            Gamepad.current
        );
    }
    public void PlayerReconnected()
    {
        Time.timeScale = 1f;
        Debug.Log("player reconnected");
    }
}
