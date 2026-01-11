using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections.Generic;

public class SelectPlayerBehaviour : MonoBehaviour
{
    [SerializeField] PlayerInput _player1Input;
    [SerializeField] PlayerInput _player2Input;
    private Button _playerButton;
    public List<Gamepad> _gamepad;

    private void Awake()
    {
        _playerButton = GetComponent<Button>();
    }
    public void OnPlayerSelect()
    {
        if (Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            switch(_playerButton.name)
            {
                case "Molly": SwitchToGamepad(_player1Input); break;
                case "Henry": SwitchToGamepad(_player2Input); break;
            }
        }
        else if (Keyboard.current != null && Keyboard.current.enterKey.wasPressedThisFrame)
        {
            switch (_playerButton.name)
            {
                case "Molly": SwitchToKeyboard(_player1Input); break;
                case "Henry": SwitchToKeyboard(_player2Input); break;
            }
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
}
