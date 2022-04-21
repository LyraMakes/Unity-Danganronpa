using System;

public class ButtonPressedEventArgs : EventArgs
{
    public ButtonPressedEventArgs()
    {
        Button = Buttons.NONE;
    }
    
    public ButtonPressedEventArgs(Buttons button)
    {
        Button = button;
    }
    
    public Buttons Button { get; set; }
}