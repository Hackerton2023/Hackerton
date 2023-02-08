//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CharacterMove : MonoBehaviour
//{
//    //private Rigidbody rb;
//    public Transform cameraTransform;

//    //public CharacterController characterController;

//    public float moveSpeed = 1f;

//    public float jumpSpeed = 5f;

//    public float gravity = -20f;

//    public float yVelocity = 0;
//    // Start is called before the first frame update
//    void Start()
//    {
//        //rb = GetComponent<Rigidbody>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        transform.forward = cameraTransform.forward;
//        float h = Input.GetAxis("Horizontal");

//        float v = Input.GetAxis("Vertical");

//        Vector3 moveDirection = transform.forward * v + transform.right * h;

//        moveDirection = cameraTransform.TransformDirection(moveDirection);
//        moveDirection.Normalize();
//        moveDirection *= moveSpeed;
//        //print(moveDirection);
//        //점프
//        //if (characterController.isGrounded)
//        //{
//        //    yVelocity = 0;
//        //}
//        //    if (Input.GetKeyDown(KeyCode.Space))
//        //    {
//        //        yVelocity = jumpSpeed;
//        //    }
//        //}


//        //yVelocity += (gravity * Time.deltaTime);

//        //moveDirection.y = yVelocity;

//        //characterController.Move(moveDirection * Time.deltaTime);

//        transform.position += moveDirection * Time.deltaTime;
//        //rb.AddForce(moveDirection);

//        //떨어졌을때 돌아오기
//        //if (transform.position.y < -30)
//        //{
//        //    transform.position =
//        //    new Vector3(0, 10, 0);
//        //}



//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMove : MonoBehaviour
{
    public float turnSpeed = 4.0f; // 마우스 감도
    private float xRotate = 0.0f;
    Rigidbody body;
    public float moveSpeed = 4.0f; // 기본속도
    public float jumpForce = 10.0f; // 점프강도
    public float RunSpeed; // 달리기 속도
    public static bool isGround = true; // 땅에 붙어있는가?
    public static bool isRun = false; // 달리고 있는가?
    private int Tree = 3;

    void Start()
    {
        body = GetComponent<Rigidbody>();           // Rigidbody중력값 받기
        transform.rotation = Quaternion.identity;   // 쿼터니언으로 각도 받기
    }

    void FixedUpdate()
    {
        Move();
        if (Input.GetKey(KeyCode.Space) && isGround)
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            isGround = false;
        }
        //Jump();
    }

    void Move()
    {
        // X로 돌리기
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        // y로 돌리기
        float yRotate = transform.eulerAngles.y + yRotateSize;
        // y축으로 돌리기
        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
        // y축으로 돌리기
        // Clamp 는 각도를 고정하는 함수
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);
        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);

        //  이동
        Vector3 move = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");

        // 달리기
        transform.position += move * moveSpeed * Time.deltaTime;

        // isRun 초기화
        if (Input.GetKey(KeyCode.W) && isRun == true && !Input.GetKey(KeyCode.LeftShift))
        {
            isRun = false;
        }
        if (Input.GetKey(KeyCode.A) && isRun == true && !Input.GetKey(KeyCode.LeftShift))
        {
            isRun = false;
        }
        if (Input.GetKey(KeyCode.S) && isRun == true && !Input.GetKey(KeyCode.LeftShift))
        {
            isRun = false;
        }
        if (Input.GetKey(KeyCode.D) && isRun == true && !Input.GetKey(KeyCode.LeftShift))
        {
            isRun = false;
        }

        //void Jump() // 점프
        //{
        //    if (Input.GetKey(KeyCode.Space) && isGround)
        //    {
        //        body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        //        isGround = false;
        //    }
        //}

        // ~에 닿았는가 (땅에 닿았는가)
       
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
}
