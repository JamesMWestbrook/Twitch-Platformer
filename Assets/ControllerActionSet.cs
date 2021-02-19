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

    public ControllerActionSet()
    {
        Left = CreatePlayerAction("Left");
        Right = CreatePlayerAction("Right");
        Up = CreatePlayerAction("Up");
        Down = CreatePlayerAction("Down");
        Move = CreateTwoAxisPlayerAction(Left, Right, Down, Up);
        Jump = CreatePlayerAction("Jump");
    }

    public  ControllerActionSet CreateWithJoyStickBindings()
    {
        var actions = new ControllerActionSet();
        actions.Left.AddDefaultBinding(InputControlType.LeftStickLeft);
        actions.Right.AddDefaultBinding(InputControlType.LeftStickRight);
        actions.Up.AddDefaultBinding(InputControlType.LeftStickUp);
        actions.Down.AddDefaultBinding(InputControlType.LeftStickDown);

        actions.Jump.AddDefaultBinding(InputControlType.Action1);
        return actions;
    }
    public static ControllerActionSet CreateWithKeyboardBindings()
    {
        var actions = new ControllerActionSet();

        
        return actions;
    }
}
