using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player_STG : MonoBehaviour
{
    public GameObject Item1;
    private bool isFadeIn = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Item_test.Instance != null && Item_test.Instance.button1)
        {
            StartCoroutine(FadeInStart());
            isFadeIn = true;    
        }
    }

    public IEnumerator FadeInStart()
    {
        Item1.SetActive(true);
        for(float f = 1.0f; f > 0; f -= 0.02f)
        {
            Color c = Item1.GetComponent<Image>().color;
            c.a = f;
            Item1.GetComponent<Image>().color = c;
            isFadeIn = false;
            yield return null;
        }
        yield return new WaitForSeconds(1);
    }
}
