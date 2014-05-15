using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        InputManager.Instance.MouseClick += HandleClick;
        InputManager.Instance.KeyboardPress += HandleKeyPress;
    }

    void HandleClick(MouseEventArgs args)
    {
        switch (args.button)
        {
            //left click
            case 0:
                if (args.buttonState == MouseEventArgs.ButtonState.Down)
                {
                    Fire(new Vector2(args.x, args.y));
                }

                break;
            //right click
            case 1:
                if (args.buttonState == MouseEventArgs.ButtonState.Down)
                {
                    MoveTo(new Vector2(args.x, args.y));
                }
                break;
            case 2:
                break;

            default:
                break;
        }

    }
    void HandleKeyPress(KeyboardEventArgs args)
    {
        switch (args.key)
        {

            case KeyCode.Alpha0:
                if (args.keyState == KeyboardEventArgs.KeyState.Down)
                    CastSpell(0);
                break;
            case KeyCode.Alpha1:
                if (args.keyState == KeyboardEventArgs.KeyState.Down)
                    CastSpell(1);
                break;
            case KeyCode.Alpha2:
                if (args.keyState == KeyboardEventArgs.KeyState.Down)
                    CastSpell(2);
                break;
            case KeyCode.Alpha3:
                if (args.keyState == KeyboardEventArgs.KeyState.Down)
                    CastSpell(3);
                break;
            case KeyCode.Alpha4:
                if (args.keyState == KeyboardEventArgs.KeyState.Down)
                    CastSpell(4);
                break;
            case KeyCode.Alpha5:
                if (args.keyState == KeyboardEventArgs.KeyState.Down)
                    CastSpell(5);
                break;
            case KeyCode.Alpha6:
                if (args.keyState == KeyboardEventArgs.KeyState.Down)
                    CastSpell(6);
                break;
            case KeyCode.Alpha7:
                if (args.keyState == KeyboardEventArgs.KeyState.Down)
                    CastSpell(7);
                break;
            case KeyCode.Alpha8:
                if (args.keyState == KeyboardEventArgs.KeyState.Down)
                    CastSpell(8);
                break;
            case KeyCode.Alpha9:
                if (args.keyState == KeyboardEventArgs.KeyState.Down)
                    CastSpell(9);
                break;

            case KeyCode.W:
                if (args.keyState == KeyboardEventArgs.KeyState.Hold)
                    Move(Vector3.forward);
                break;
            case KeyCode.A:
                if (args.keyState == KeyboardEventArgs.KeyState.Hold)
                    Move(Vector3.left);
                break;
            case KeyCode.S:
                if (args.keyState == KeyboardEventArgs.KeyState.Hold)
                    Move(Vector3.back);
                break;
            case KeyCode.D:
                if (args.keyState == KeyboardEventArgs.KeyState.Hold)
                    Move(Vector3.right);
                break;

            case KeyCode.E:
                if (args.keyState == KeyboardEventArgs.KeyState.Down)
                    Interact();
                break;
            case KeyCode.F:
                break;
            case KeyCode.Q:
                break;

            case KeyCode.Escape:

                break;
            case KeyCode.Space:
                if (args.keyState == KeyboardEventArgs.KeyState.Down)
                    Jump();
                break;


            default:
                break;
        }
    }


    void Fire(Vector2 pos)
    {
        Debug.Log("Fire at " + pos);
    }
    void MoveTo(Vector2 pos)
    {
        Debug.Log("Move to " + pos);
    }
    void CastSpell(int spellIndex)
    {
        Debug.Log("Cast spell " + spellIndex);
    }
    void Move(Vector3 dir)
    {
        Debug.Log("Moving along direction: " + dir);
    }
    void Interact()
    {
        Debug.Log("Interact");
    }
    void Jump()
    {
        Debug.Log("jump");
    }
}
