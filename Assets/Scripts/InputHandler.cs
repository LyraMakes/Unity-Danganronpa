using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public event EventHandler<ButtonPressedEventArgs> OnButtonPressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            OnButtonPress(new ButtonPressedEventArgs(Buttons.CROSS));

        
    }

    private void OnButtonPress(ButtonPressedEventArgs e) => OnButtonPressed?.Invoke(this, e);

    public static bool IsButtonPressed(string inputName)
    {
        return Input.GetButtonDown(inputName);
    }
}