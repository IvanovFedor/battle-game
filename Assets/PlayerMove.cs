using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Joystick joystick;
    public Joystick joystick2;
    public Vector3 MoveInput;
    public Vector3 moveVelocity;
    public float speed;
    public Rigidbody rb;
    public float ranz;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        MoveInput = new Vector3(joystick.Horizontal, 0 , joystick.Vertical);
        moveVelocity = MoveInput.normalized * speed;
        if (joystick2.Direction != Vector2.zero &&Mathf.Abs(joystick2.Horizontal) > 0.3f || Mathf.Abs(joystick2.Vertical) > 0.3f)
        {
            ranz = Mathf.Atan2(joystick2.Vertical, joystick2.Horizontal) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, -ranz+90f,  0);
        }

    }
}
