using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Player : MonoBehaviour
{
    public ControllerActionSet actions;
    public bool Grounded = true;
    public float JumpForce = 800;
    
    public float MoveSpeed;
    public float RunSpeed;

    [SerializeField] private Rigidbody RB;
    public Transform Camera;
    // Start is called before the first frame update
    void Awake()
    {
        actions = new ControllerActionSet();
        actions = actions.CreateWithAllBindings();
        CinemachineCore.GetInputAxis = GetAxisCustom;
    }
    public float GetAxisCustom(string axisName)
    {
        if(axisName == "x")
        {
            return actions.CameraMove.X;
        }
        else if(axisName == "y")
        {
            return actions.CameraMove.Y;
        }
        return 0;
    }
    
    void Update()
    {
    }
    private void FixedUpdate()
    {
        Rotation();

        Movement();
        VerticalMovement();

    }
    private void Rotation()
    {
        Vector2 input = new Vector2(actions.Move.X, actions.Move.Y);
        Vector3 NextDir = new Vector3(input.x, 0, input.y);
        NextDir = Camera.TransformDirection(NextDir);
        NextDir.y = 0f;
        if (actions.Move)
        {
            transform.rotation = Quaternion.LookRotation(NextDir);
        }

    }
    private void Movement()
    {
        float speed = MoveSpeed;
        float value =Mathf.Clamp( Mathf.Abs(actions.Move.X) + Mathf.Abs(actions.Move.Y), 0, 1);

        if (actions.Move)
        {
            float YVelocity = RB.velocity.y;
            // transform.Translate( transform.forward * value * speed * Time.deltaTime, Space.World);
            RB.velocity = transform.forward * value * speed * Time.deltaTime;
            RB.velocity = new Vector3(RB.velocity.x, YVelocity, RB.velocity.z);
        }
    }

    private void VerticalMovement()
    {
        if (actions.Jump && Grounded)
        {
            Grounded = false;
            RB.AddForce(Vector3.up * JumpForce);
        }
        Vector3 velocity = RB.velocity;
        if (velocity.y < 0)
        {
         //   RB.drag = 3;
        }
        else
        {
     //       RB.drag = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor") Grounded = true;
    }
}
