using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class ControllerActionSet : PlayerActionSet
{
    public PlayerAction Left;
    public PlayerAction Right;
    public PlayerAction Up;
    public PlayerAction Down;
    public PlayerTwoAxisAction Move;
    public PlayerAction Jump;

    public PlayerAction CameraLeft;
    public PlayerAction CameraRight;
    public PlayerAction CameraUp;
    public PlayerAction CameraDown;
    public PlayerOneAxisAction CameraHorizontal;
    public PlayerOneAxisAction CameraVertical;
    public PlayerTwoAxisAction CameraMove;
    public PlayerAction CameraToggle;


    public ControllerActionSet()
    {
        Left = CreatePlayerAction("Left");
        Right = CreatePlayerAction("Right");
        Up = CreatePlayerAction("Up");
        Down = CreatePlayerAction("Down");
        Move = CreateTwoAxisPlayerAction(Left, Right, Down, Up);
        Jump = CreatePlayerAction("Jump");

        CameraLeft = CreatePlayerAction("Camera Left");
        CameraRight = CreatePlayerAction("Camera Right");
        CameraHorizontal = CreateOneAxisPlayerAction(CameraLeft, CameraRight);
        CameraUp = CreatePlayerAction("Camera Up");
        CameraDown = CreatePlayerAction("Camera Down");
        CameraVertical = CreateOneAxisPlayerAction(CameraDown, CameraUp);

        CameraMove = CreateTwoAxisPlayerAction(CameraLeft, CameraRight, CameraDown, CameraUp);
    }
    public ControllerActionSet CreateWithAllBindings()
    {
        var actions = new ControllerActionSet();
        //Controller
        //Movement
        actions.Left.AddDefaultBinding(InputControlType.LeftStickLeft);
        actions.Right.AddDefaultBinding(InputControlType.LeftStickRight);
        actions.Up.AddDefaultBinding(InputControlType.LeftStickUp);
        actions.Down.AddDefaultBinding(InputControlType.LeftStickDown);
        //Buttons
        actions.Jump.AddDefaultBinding(InputControlType.Action1);
        //Camera
        actions.CameraLeft.AddDefaultBinding(InputControlType.RightStickLeft);
        actions.CameraRight.AddDefaultBinding(InputControlType.RightStickRight);
        actions.CameraUp.AddDefaultBinding(InputControlType.RightStickUp);
        actions.CameraDown.AddDefaultBinding(InputControlType.RightStickDown);

        //Keyboard
        //Movement
        actions.Left.AddDefaultBinding(Key.A);
        actions.Right.AddDefaultBinding(Key.D);
        actions.Up.AddDefaultBinding(Key.W);
        actions.Down.AddDefaultBinding(Key.S);
        //Buttons
        actions.Jump.AddDefaultBinding(Key.Space);
        //Camera
        actions.CameraLeft.AddDefaultBinding(Key.LeftArrow);
        actions.CameraRight.AddDefaultBinding(Key.RightArrow);
        actions.CameraUp.AddDefaultBinding(Key.UpArrow);
        actions.CameraDown.AddDefaultBinding(Key.DownArrow);
        //Mouse Camera
        actions.CameraLeft.AddDefaultBinding(Mouse.NegativeX);
        actions.CameraRight.AddDefaultBinding(Mouse.PositiveX);
        actions.CameraUp.AddDefaultBinding(Mouse.PositiveY);
        actions.CameraDown.AddDefaultBinding(Mouse.NegativeY);


        return actions;
    }
    public  ControllerActionSet CreateWithJoyStickBindings()
    {
        var actions = new ControllerActionSet();
        //Movement
        actions.Left.AddDefaultBinding(InputControlType.LeftStickLeft);
        actions.Right.AddDefaultBinding(InputControlType.LeftStickRight);
        actions.Up.AddDefaultBinding(InputControlType.LeftStickUp);
        actions.Down.AddDefaultBinding(InputControlType.LeftStickDown);
        //Buttons
        actions.Jump.AddDefaultBinding(InputControlType.Action1);
        //Camera
        actions.CameraLeft.AddDefaultBinding(InputControlType.RightStickLeft);
        actions.CameraRight.AddDefaultBinding(InputControlType.RightStickRight);
        actions.CameraUp.AddDefaultBinding(InputControlType.RightStickUp);
        actions.CameraDown.AddDefaultBinding(InputControlType.RightStickDown);
        return actions;
    }
    public static ControllerActionSet CreateWithKeyboardBindings()
    {
        var actions = new ControllerActionSet();
        //Movement
        actions.Left.AddDefaultBinding(Key.A);
        actions.Right.AddDefaultBinding(Key.D);
        actions.Up.AddDefaultBinding(Key.W);
        actions.Down.AddDefaultBinding(Key.S);
        //Buttons
        actions.Jump.AddDefaultBinding(Key.Space);
        //Camera
        actions.CameraLeft.AddDefaultBinding(Key.LeftArrow);
        actions.CameraRight.AddDefaultBinding(Key.RightArrow);
        actions.CameraUp.AddDefaultBinding(Key.UpArrow);
        actions.CameraDown.AddDefaultBinding(Key.DownArrow);
        //Mouse Camera
        actions.CameraLeft.AddDefaultBinding(Mouse.NegativeX);
        actions.CameraRight.AddDefaultBinding(Mouse.PositiveX);
        actions.CameraUp.AddDefaultBinding(Mouse.PositiveY);
        actions.CameraDown.AddDefaultBinding(Mouse.NegativeY);
        return actions;
    }
}
