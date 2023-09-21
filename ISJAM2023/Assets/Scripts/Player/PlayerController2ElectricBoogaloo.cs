using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2ElectricBoogaloo : MonoBehaviour
{
    public GameObject cameraRot;
    public CharacterController controller;
    public float speed;
    public float gravity;
    public bool isGrounded;

    public float jumpHeight;

    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, transform.localScale.y + 0.2f, LayerMask.GetMask("Ground"));
        Vector3 camRot = new Vector3(transform.eulerAngles.x, cameraRot.transform.eulerAngles.y, transform.eulerAngles.z);
        transform.rotation = Quaternion.Euler(camRot);

        Movement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Movement()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        //Vector3 move = transform.forward * v + transform.right * h;
        controller.Move(Vector3.ClampMagnitude((transform.forward * v + transform.right * h), 1f) * speed * Time.deltaTime);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2;

        }

        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * 2 * gravity);
    }
}
