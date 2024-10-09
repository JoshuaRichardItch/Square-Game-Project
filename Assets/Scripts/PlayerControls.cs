using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public int speed = 5;
    public float horizontalInput;
    public float verticalInput;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    private float heightLimit = 2.091547f;
    public GameObject floor;

    public bool isGrounded;
    Rigidbody rigidBody;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.5f, 0.0f);
    }


    void OnCollisionStay()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        if (transform.position.y > heightLimit)
        {
            transform.position = new Vector3(transform.position.x, heightLimit, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rigidBody.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
