using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpen : MonoBehaviour
{
    public GameObject Option;
    public Canvas Cut;

    public void ClickPanel()
    {
        Option.SetActive(true);
    }
    public void ClickGame()
    {
        Option.SetActive(false);
    }

    public void ClickPanel2()
    {
        Cut.gameObject.SetActive(false);
        Option.SetActive(true);
    }
}
