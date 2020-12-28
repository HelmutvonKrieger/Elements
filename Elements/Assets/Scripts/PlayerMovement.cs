using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float MovementSpeed = 20F;

    [SerializeField]
    private float SprintMultiplier = 1.5f;

    [SerializeField]
    private float MoveLimiter = 0.7f;

    [SerializeField]
    public ControlScheme ControlScheme;

    //private Vector2 moveDirection = Vector2.zero;
    //private Vector2 inputDirection = Vector2.zero;
    //private Vector2 flatMovement = Vector2.zero;

    //private CharacterController controller;

    private Rigidbody2D rigidbody;
    private float horizontal = 0f;
    private float vertical = 0f;

    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        //controller = GetComponent<CharacterController>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Keep the player locked to what the camera can see
        pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            horizontal *= SprintMultiplier;
            vertical *= SprintMultiplier;
        }
    }

    private void FixedUpdate()
    {
        // Account for diagonal movement speed
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= MoveLimiter;
            vertical *= MoveLimiter;
        }

        rigidbody.velocity = new Vector2(horizontal * MovementSpeed, vertical * MovementSpeed);
    }
}

public enum ControlScheme
{
    Mouse,
    Keyboard,
    Both,
    Controller
}