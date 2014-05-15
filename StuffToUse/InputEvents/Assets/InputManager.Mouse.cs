using UnityEngine;
using System.Collections;

public partial class InputManager{

    void CheckMouseClick()
    {

        //left clicks
        if (Input.GetMouseButtonDown(0))
        {
            if (MouseClick != null)
            {
                MouseClick(new MouseEventArgs(Input.mousePosition.x, Input.mousePosition.y, 0, MouseEventArgs.ButtonState.Down));
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (MouseClick != null)
            {
                MouseClick(new MouseEventArgs(Input.mousePosition.x, Input.mousePosition.y, 0, MouseEventArgs.ButtonState.Up));
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (MouseClick != null)
            {
                MouseClick(new MouseEventArgs(Input.mousePosition.x, Input.mousePosition.y, 1, MouseEventArgs.ButtonState.Hold));
            }
        }

        //right clicks
        if (Input.GetMouseButtonDown(1))
        {
            if (MouseClick != null)
            {
                MouseClick(new MouseEventArgs(Input.mousePosition.x, Input.mousePosition.y, 1, MouseEventArgs.ButtonState.Down));
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            if (MouseClick != null)
            {
                MouseClick(new MouseEventArgs(Input.mousePosition.x, Input.mousePosition.y, 1, MouseEventArgs.ButtonState.Up));
            }
        }
        if (Input.GetMouseButton(1))
        {
            if (MouseClick != null)
            {
                MouseClick(new MouseEventArgs(Input.mousePosition.x, Input.mousePosition.y, 1, MouseEventArgs.ButtonState.Hold));
            }
        }

        //middle clicks
        if (Input.GetMouseButtonDown(2))
        {
            if (MouseClick != null)
            {
                MouseClick(new MouseEventArgs(Input.mousePosition.x, Input.mousePosition.y, 1, MouseEventArgs.ButtonState.Down));
            }
        }
        if (Input.GetMouseButtonUp(2))
        {
            if (MouseClick != null)
            {
                MouseClick(new MouseEventArgs(Input.mousePosition.x, Input.mousePosition.y, 1, MouseEventArgs.ButtonState.Up));
            }
        }
        if (Input.GetMouseButton(2))
        {
            if (MouseClick != null)
            {
                MouseClick(new MouseEventArgs(Input.mousePosition.x, Input.mousePosition.y, 2, MouseEventArgs.ButtonState.Hold));
            }
        }
    }
    

}
