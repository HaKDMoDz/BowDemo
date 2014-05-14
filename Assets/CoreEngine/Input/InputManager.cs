using UnityEngine;
using System.Collections;

public partial class InputManager : SingletonComponent<InputManager> {

    //delegates for input related actions
    public delegate void MouseAction(MouseEventArgs args);
    public delegate void KeyboardAction(KeyboardEventArgs args);
    public delegate void MouseMoveAction(MouseMoveEventArgs args);

    //events raised based on input - register methods to these events
    public event MouseAction OnMouseClick = new MouseAction(delegate (MouseEventArgs args){}); //this prevents a null exception, and avoids an if null check before every event raise
    public event KeyboardAction OnKeyboardPress=new KeyboardAction(delegate (KeyboardEventArgs args){});
    public event MouseMoveAction OnMouseMove=new MouseMoveAction(delegate (MouseMoveEventArgs args){});

    void Update()
    {
        //methods that check for input and raise the relevant events
        //defined in the other partial classes
        CheckMouseClick();
        CheckMouseMove();
        CheckKeyboardPress();
    }

    
}
