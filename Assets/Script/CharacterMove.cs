using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
   // private Rigidbody rb;
    public Transform cameraTransform;

    //public CharacterController characterController;

    public float moveSpeed = 1f;

    public float jumpSpeed = 5f;

    public float gravity = -20f;

    public float yVelocity = 0;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = cameraTransform.forward;
        float h = Input.GetAxis("Horizontal");

        float v = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * v + transform.right * h;

        //moveDirection = cameraTransform.TransformDirection(moveDirection);
        //moveDirection.Normalize();
        moveDirection *= moveSpeed;
        //print(moveDirection);
        //점프
        //if (characterController.isGrounded)
        //{
        //    yVelocity = 0;

        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        yVelocity = jumpSpeed;
        //    }
        //}


        //yVelocity += (gravity * Time.deltaTime);

        //moveDirection.y = yVelocity;

        //characterController.Move(moveDirection * Time.deltaTime);

        transform.position += moveDirection * Time.deltaTime;
        //rb.AddForce(moveDirection);

        //떨어졌을때 돌아오기
        //if (transform.position.y < -30)
        //{
        //    transform.position =
        //    new Vector3(0, 10, 0);
        //}
    
    
    
    }
}
