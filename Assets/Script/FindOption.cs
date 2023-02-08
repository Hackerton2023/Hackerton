using UnityEngine;
using UnityEngine.EventSystems;

public class FindOption : MonoBehaviour, IPointerClickHandler
{
    public bool isOptionActive;

    public void OnPointerClick(PointerEventData eventData)
    {
        CanvasGroup canvasGroup = GameObject.FindWithTag("Option").GetComponent<CanvasGroup>();

        if (canvasGroup.alpha == 1)
        {
            isOptionActive = false;
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
        else
        {
            isOptionActive = true;
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
    }
}
