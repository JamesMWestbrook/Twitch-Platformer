using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    ControllerActionSet actions;
    public bool Grounded = true;
    public float JumpForce = 500;
    public float MoveSpeed;
    [SerializeField] private Rigidbody RB;


    // Start is called before the first frame update
    void Start()
    {
        actions = new ControllerActionSet();
        actions = actions.CreateWithJoyStickBindings();

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
        transform.Translate(Vector3.forward * input.y * MoveSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * input.x * MoveSpeed * Time.deltaTime);
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
            RB.drag = 3;
        }
        else
        {
            RB.drag = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor") Grounded = true;
    }
}
