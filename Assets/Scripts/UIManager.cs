using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] GameObject mainCanvas;
    [SerializeField] Animator uiAnimation;
    [SerializeField] CanvasGroup canvasToClick;
    [SerializeField] Text startTxt;
    private void Start()
    {
        if (instance == null)
            instance = this;
        else Destroy(this.gameObject);
    }

    public void HideUI()
    {
        uiAnimation.Play("CanvasInvisible");
        canvasToClick.interactable = false;
    }

    public void UIState(bool state)
    {
        mainCanvas.SetActive(state);
    }

    public void ShowUI()
    {
        mainCanvas.SetActive(true);
        startTxt.text = "Touch to restart game";
        uiAnimation.Play("CanvasVisible");
        StartCoroutine(PreventClick());
    }

    IEnumerator PreventClick()
    {
        yield return new WaitForSeconds(0.5f);
        canvasToClick.interactable = true;

    }
}
