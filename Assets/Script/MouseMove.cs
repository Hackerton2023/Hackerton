using UnityEngine;

public class MouseMove : MonoBehaviour
{

    public float sesitivity = 500f;

    public float rotationX;

    public float rotationY;

    public bool Mouse;

    public float score = 0;

    public GameObject baseUI;

    private CanvasGroup option;

    private Clear clear;

    // Start is called before the first frame update
    void Start()
    {
        //findOption = FindObjectOfType<FindOption>();
        option = GameObject.FindWithTag("Option").GetComponent<CanvasGroup>();
        clear = FindObjectOfType<Clear>();
        Mouse = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (option.alpha == 1 || baseUI.activeSelf)
        {
            Cursor.visible = true;
            return;
        }


        Cursor.visible = Mouse;
        float mouseMoveX = Input.GetAxis("Mouse X");

        float mouseMoveY = Input.GetAxis("Mouse Y");

        rotationY += mouseMoveX * sesitivity * Time.deltaTime;

        rotationX -= mouseMoveY * sesitivity * Time.deltaTime;

        if (rotationX > 35f)
        {
            rotationX = 35f;
        }

        if (rotationX < -30f)
        {
            rotationX = -30f;
        }

        transform.eulerAngles = new Vector3(rotationX, rotationY, 0);

        if (score >= 10)
        {
            Mouse = true;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag("EGGGGGGG"))
        {

            collision.gameObject.SetActive(false);
            score += 1;

        }

    }

}
