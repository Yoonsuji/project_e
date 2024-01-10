using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public bool right;
    public bool able;
    public bool ringOut;
    public float speed;
    public Player player;
    public GameObject click;
    private void Update()
    {
        if(able)
        {
            if (GameManager.stage == 0 && click != null)
            {
                click.SetActive(false);
            }
            if(ringOut&&player!=null) player.isRingOut = true;

            if(right)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime); 
            }

            else
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime); 
            }

            Invoke("Hide", 3f);
        }
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
