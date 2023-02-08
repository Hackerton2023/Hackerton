using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_am_happy : MonoBehaviour
{

    public static bool isPause = false;

    [SerializeField] private CanvasGroup go_BaseUi;
    //[SerializeField] private FindOption findOption;
    private CanvasGroup option;

    private void Start()
    {
        option = GameObject.FindWithTag("Option").GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (option.alpha == 1) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPause)
            {
                CallMenu();
            }
            else
            {
                CloseMenu();
            }
        }

       
    }

    private void CallMenu()
    {
        MouseCursor.SetActive(true);
        isPause = true;
        go_BaseUi.gameObject.SetActive(true);
        //go_BaseUi.alpha = 1.0f;
        Time.timeScale = 0f;
    }

    private void CloseMenu()
    {
        MouseCursor.SetActive(false);
        isPause = false;
        go_BaseUi.gameObject.SetActive(false);
        //go_BaseUi.alpha = 0;
        Time.timeScale = 1f;
    }

    public void Closemenu()
    {
        MouseCursor.SetActive(false);
        isPause = false;
        go_BaseUi.gameObject.SetActive(false);
        //go_BaseUi.alpha = 0;
        Time.timeScale = 1f;
    }

    public void ClickSave()
    {
        Debug.Log("계속하기");
    }
    public void ClickExit()
    {
        Debug.Log("게임종료");
        Application.Quit();
    }

}
