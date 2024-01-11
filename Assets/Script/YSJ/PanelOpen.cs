using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpen : MonoBehaviour
{
    public GameObject Option;

    public void ClickPanel()
    {
        Option.SetActive(true);
    }
    public void ClickGame()
    {
        Option.SetActive(false);
    }
}
