using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed = 5f;

    private Vector3 forward, right, moveInput;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
    }

    private void FixedUpdate()
    {
        var newVelocity = moveInput * speed;
        newVelocity.y = rb.velocity.y;
        rb.velocity = newVelocity;
    }

    void MovementInput() {
        Vector3 xInput = Input.GetKey(KeyCode.D) ? right * 1 : Input.GetKey(KeyCode.A) ? right * -1 : Vector3.zero;
        Vector3 zInput = Input.GetKey(KeyCode.W) ? forward * 1 : Input.GetKey(KeyCode.S) ? forward * -1 : Vector3.zero;
        moveInput = (xInput + zInput).normalized;

        if (moveInput == Vector3.zero) return;
        transform.forward = moveInput;
    }
}
