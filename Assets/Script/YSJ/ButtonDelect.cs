using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDelect : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public GameObject Item1;
    public GameObject Item2;

    private bool isPressed = false;
    private ButtonDelect itemTestScript;

    void Start()
    {
        button1.interactable = false; 
        button2.interactable = false;

        button1.onClick.AddListener(() => OnButtonClick(button1));
        button2.onClick.AddListener(() => OnButtonClick(button2));
    }


    void OnButtonClick(Button clickedButton)
    {
        if (isPressed)
            return;

        isPressed = true;

        LeanTween.scale(clickedButton.gameObject, Vector3.one * 1.2f, 0.3f)
            .setEase(LeanTweenType.easeOutQuad)
            .setOnComplete(() =>
            {
                LeanTween.scale(clickedButton.gameObject, Vector3.zero, 2.0f)
                    .setEase(LeanTweenType.easeOutQuad)
                    .setOnComplete(() => clickedButton.gameObject.SetActive(false));

                StartCoroutine(FadeInItem());
            });

        Button otherButton = (clickedButton == button1) ? button2 : button1;
        LeanTween.scale(otherButton.gameObject, Vector3.one * 1.2f, 0.3f)
            .setEase(LeanTweenType.easeOutQuad)
            .setOnComplete(() =>
            {
                LeanTween.scale(otherButton.gameObject, Vector3.zero, 2.0f)
                    .setEase(LeanTweenType.easeOutQuad)
                    .setOnComplete(() => otherButton.gameObject.SetActive(false));
                StartCoroutine(FadeInItem2());
            });
    }

    IEnumerator FadeInItem()
    {
        yield return new WaitForSeconds(0.5f); 

        Item1.SetActive(true);

        for (float f = 0.0f; f <= 1.0f; f += 0.02f)
        {
            Color c = Item1.GetComponent<Image>().color;
            c.a = f;
            Item1.GetComponent<Image>().color = c;
            yield return null;
        }

        isPressed = false;
    }
    IEnumerator FadeInItem2()
    {
        yield return new WaitForSeconds(0.5f);

        Item2.SetActive(true);

        for (float f = 0.0f; f <= 1.0f; f += 0.02f)
        {
            Color c = Item2.GetComponent<Image>().color;
            c.a = f;
            Item2.GetComponent<Image>().color = c;
            yield return null;
        }
    }

}
