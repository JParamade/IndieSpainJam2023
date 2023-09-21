using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject cameraRot;
    public Rigidbody rb;

    public bool isGrounded;
    public float dragg;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, transform.localScale.y * 0.5f + 0.2f, LayerMask.GetMask("Ground"));
        //Movement();

        if (isGrounded)
        {
            rb.drag = dragg;
        }
        else
        {
            rb.drag = 0;
        }
    }
    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        /*if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }*/
        Vector3 camRot = new Vector3(transform.eulerAngles.x, cameraRot.transform.eulerAngles.y, transform.eulerAngles.z);
        transform.rotation = Quaternion.Euler(camRot);

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rb.AddForce((transform.forward * v + transform.right * h) * 70f, ForceMode.Force);

    }
}
