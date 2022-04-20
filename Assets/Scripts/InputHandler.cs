
using UnityEngine;

public class InputHandler
{
    public static bool IsButtonPressed(string inputName)
    {
        return Input.GetButtonDown(inputName);
    }
    
    
}