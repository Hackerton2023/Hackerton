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
//        //����
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

//        //���������� ���ƿ���
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
    public float turnSpeed = 4.0f; // ���콺 ����
    private float xRotate = 0.0f;
    Rigidbody body;
    public float moveSpeed = 4.0f; // �⺻�ӵ�
    public float jumpForce = 10.0f; // ��������
    public float RunSpeed; // �޸��� �ӵ�
    public static bool isGround = true; // ���� �پ��ִ°�?
    public static bool isRun = false; // �޸��� �ִ°�?
    private int Tree = 3;

    void Start()
    {
        body = GetComponent<Rigidbody>();           // Rigidbody�߷°� �ޱ�
        transform.rotation = Quaternion.identity;   // ���ʹϾ����� ���� �ޱ�
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
        // X�� ������
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        // y�� ������
        float yRotate = transform.eulerAngles.y + yRotateSize;
        // y������ ������
        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
        // y������ ������
        // Clamp �� ������ �����ϴ� �Լ�
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);
        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);

        //  �̵�
        Vector3 move = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");

        // �޸���
        transform.position += move * moveSpeed * Time.deltaTime;

        // isRun �ʱ�ȭ
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

        //void Jump() // ����
        //{
        //    if (Input.GetKey(KeyCode.Space) && isGround)
        //    {
        //        body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        //        isGround = false;
        //    }
        //}

        // ~�� ��Ҵ°� (���� ��Ҵ°�)
       
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
}
