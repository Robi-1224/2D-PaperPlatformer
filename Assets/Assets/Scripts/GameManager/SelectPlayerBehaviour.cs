using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.iOS;

public class SelectPlayerBehaviour : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] PlayerInput _player1Input;
    [SerializeField] PlayerInput _player2Input;
    [SerializeField] GameObject _characterSelectPanel;
    private Button _playerButton;

    [Header("Variables")]
    private bool _player1Slotted = false;
    private bool _player2Slotted = false;


    private void Awake()
    {
        if (!Gamepad.current.enabled || !Keyboard.current.enabled)
        {
            InputSystem.EnableDevice(Gamepad.current);
            InputSystem.EnableDevice(Keyboard.current);
        }
        _playerButton = GetComponent<Button>();
    }
    private void PlayersSlottedBehaviour()
    {
        if (_player2Slotted && _player1Slotted)
        {
            Debug.Log("All Slotted");
            _characterSelectPanel.SetActive(false);
            InputSystem.EnableDevice(Gamepad.current);
            InputSystem.EnableDevice(Keyboard.current);
        }
    }
    public void OnPlayerSelect()
    {
        if (Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            switch(_playerButton.name)
            {
                case "Molly": SwitchToGamepad(_player1Input); InputSystem.DisableDevice(Gamepad.current);_player1Slotted = true; PlayersSlottedBehaviour(); break;
                case "Henry": SwitchToGamepad(_player2Input); InputSystem.DisableDevice(Gamepad.current); _player2Slotted = true; PlayersSlottedBehaviour(); break; 
            }
        }
        else if (Keyboard.current != null && Keyboard.current.enterKey.wasPressedThisFrame)
        {
            switch (_playerButton.name)
            {
                case "Molly": SwitchToKeyboard(_player1Input); InputSystem.DisableDevice(Keyboard.current);_player1Slotted = true; PlayersSlottedBehaviour(); break;
                case "Henry": SwitchToKeyboard(_player2Input); InputSystem.DisableDevice(Keyboard.current); _player2Slotted = true; PlayersSlottedBehaviour(); break;
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
