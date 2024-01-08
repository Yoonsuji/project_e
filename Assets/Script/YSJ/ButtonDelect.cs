using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDelect : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public GameObject Item1;
    public GameObject Item2;

    public bool isPressed = false;

    void Start()
    {
        button1.interactable = false;
        button2.interactable = false;

        button1.onClick.AddListener(() => OnButtonClick(button1, Item1));
        button2.onClick.AddListener(() => OnButtonClick(button2, Item2));
    }

    void OnButtonClick(Button clickedButton, GameObject targetItem)
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

                StartCoroutine(FadeInItem(targetItem));
            });
    }

    IEnumerator FadeInItem(GameObject item)
    {
        yield return new WaitForSeconds(0.5f);

        item.SetActive(true);

        /*for (float f = 0.0f; f <= 1.0f; f += 0.02f)
        {
            Color c = item.GetComponent<Image>().color;
            c.a = f;
            item.GetComponent<Image>().color = c;
            yield return null;
        }*/

        isPressed = false;
    }
}
