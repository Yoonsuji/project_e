using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClickReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
