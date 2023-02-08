using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonType : MonoBehaviour
{
    public BtnType currentType;
    Vector3 defaultScale;
    private CanvasGroup mainGroup = null;
    private CanvasGroup optionGroup = null;

    private void Start()
    {
        CanvasGroup[] canvasGroups = FindObjectsOfType<CanvasGroup>();

        foreach(CanvasGroup canvasGroup in canvasGroups)
        {
            if (canvasGroup.name.Equals("TitleUI"))
            {
                mainGroup = canvasGroup;
            }
            else if (canvasGroup.CompareTag("Option"))
            {
                optionGroup = canvasGroup;
            }
        }
    }

    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BtnType.Start:
                //Debug.Log("play");
                if (SceneManager.GetActiveScene().buildIndex == 0)
                {
                    SceneLoad.LoadScene("move");
                }
                break;
            case BtnType.Set:
                CanvasGroupOn(optionGroup);
                CanvasGroupOff(mainGroup);
                //Debug.Log("Set");
                break;
            case BtnType.Back:
                CanvasGroupOn(mainGroup);
                CanvasGroupOff(optionGroup);
                break;
            case BtnType.Quit:
                //Debug.Log("quit");
                Application.Quit();
                break;
            case BtnType.End:
                Debug.Log("End");
                Application.Quit();
                break;
            case BtnType.To:
                //Debug.Log("Exit");
                SceneLoad.LoadScene("Main");
                break; 
        }
    }
    public void CanvasGroupOn(CanvasGroup cg)
    {
        if (cg == null) return;
        //print("ABF:1354");
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }
    public void CanvasGroupOff(CanvasGroup cg)
    {
        if (cg == null) return;
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }
}
