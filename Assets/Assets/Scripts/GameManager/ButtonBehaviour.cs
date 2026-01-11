using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    [Header("Components")]
    private Button playerSelectButton;

    private void Awake()
    {
        playerSelectButton = GetComponent<Button>();
    }
    public void SelectCharacterBehaviour()
    {
        Selectable newButton = playerSelectButton.FindSelectableOnRight();
        newButton.Select();
        playerSelectButton.interactable = false;
    }
}
