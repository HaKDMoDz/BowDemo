using UnityEngine;
using System.Collections;

public class PlayerInput : SingletonComponent<PlayerInput> {

    PlayerMove playerMove;
    PlayerAttack playerAttack;

    public bool canMove = true;

    void Start()
    {
        InputManager.Instance.OnKeyboardPress += KeyPress;
        InputManager.Instance.OnMouseMove += MouseMove;
        InputManager.Instance.OnMouseClick += MouseClick;

        playerMove = gameObject.GetSafeComponent<PlayerMove>();
        playerAttack = gameObject.GetSafeComponent<PlayerAttack>();
    }

    void MouseClick(MouseEventArgs args)
    {
        if (canMove)
        {
            if (args.button == 0 && args.buttonState == MouseEventArgs.ButtonState.Down)
            {
                playerAttack.Shoot();
            }
        }
    }

    void KeyPress(KeyboardEventArgs args)
    {
        if (canMove)
        {
            Vector2 moveDir = Vector2.zero;

            if (args.key == KeyCode.W)
            {
                moveDir.y = 1f;
            }
            else if (args.key == KeyCode.S)
            {
                moveDir.y = -1f;
            }
            if (args.key == KeyCode.A)
            {
                moveDir.x = -1f;
            }
            else if (args.key == KeyCode.D)
            {
                moveDir.x = 1f;
            }
            playerMove.Move(moveDir);

            if (args.key == KeyCode.Space && args.keyState == KeyboardEventArgs.KeyState.Down)
            {
                playerMove.Jump();
            }
        }

    }

    void MouseMove(MouseMoveEventArgs args)
    {
        if (canMove)
        {
            playerMove.RotateLook(args.mouseMoveDir);
        }
    }
}
