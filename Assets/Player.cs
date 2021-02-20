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
    // Update is called once per frame
    void Update()
    {
        Movement();
        VerticalMovement();
    }
    private void Movement()
    {
        Vector2 input = new Vector2(actions.Move.X, actions.Move.Y);
        transform.Translate(Camera.forward * input.y * MoveSpeed * Time.deltaTime);
        transform.Translate(Camera.right * input.x * MoveSpeed * Time.deltaTime);
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
