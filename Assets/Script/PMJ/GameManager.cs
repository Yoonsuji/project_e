using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] fruits;
    public Transform fruit;
    public int fCount;
    Ring ring;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < fCount; i++)
        {
            for(int j = 0; j < fruits.Length; j++)
            {
                Instantiate(fruits[j], fruit);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

            if (hit.collider != null && hit.collider.gameObject.CompareTag("Ring"))
            {
                ring = hit.collider.gameObject.GetComponent<Ring>();
                ring.able= true;
            }

        }
    }
}
