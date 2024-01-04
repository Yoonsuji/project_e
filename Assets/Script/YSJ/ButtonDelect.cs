using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDelect : MonoBehaviour
{
    public Button button1;
    public Button button2;
    // Start is called before the first frame update
    void Start()
    {
        button1.interactable = false;
        button2.interactable = false;
        button1.onClick.AddListener(() => OnButtonClick(button1));
        button2.onClick.AddListener(() => OnButtonClick(button2));
    }

    // Update is called once per frame
    void OnButtonClick(Button clickedButton)
    {
        LeanTween.scale(clickedButton.gameObject, Vector3.one * 1.2f, 0.3f)
        .setEase(LeanTweenType.easeOutQuad)
        .setOnComplete(() =>
        {
            LeanTween.scale(clickedButton.gameObject, Vector3.zero, 2.0f)
                .setEase(LeanTweenType.easeOutQuad)
                .setOnComplete(() => clickedButton.gameObject.SetActive(false));
        });

        Button otherButton = (clickedButton == button1) ? button2 : button1;
        LeanTween.scale(otherButton.gameObject, Vector3.one * 1.2f, 0.3f)
        .setEase(LeanTweenType.easeOutQuad)
        .setOnComplete(() =>
        {
            LeanTween.scale(otherButton.gameObject, Vector3.zero, 2.0f)
                .setEase(LeanTweenType.easeOutQuad)
                .setOnComplete(() => otherButton.gameObject.SetActive(false));
        });
    }
}
