using UnityEngine;
using System.Collections;

public partial class InputManager : SingletonComponent<InputManager> {

    public delegate void MouseAction(MouseEventArgs args);
    public delegate void KeyboardAction(KeyboardEventArgs args);

    public event MouseAction MouseClick;
    public event KeyboardAction KeyboardPress;

    void Update()
    {
        CheckMouseClick();
        CheckKeyboardPress();
    }

    
}
