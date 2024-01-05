using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPower : MonoBehaviour
{
    public int enemyPower;
    public int enemyType;
    public bool type;
    public Text enemyPowerText;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        if (enemyPower > 0)
        {
            type = false;
        }
        else
        {
            type = true;
        }
    }

    void Update()
    {
        enemyPowerText.text = enemyPower.ToString();
        if (type == false)
        {
            if (enemyPower <= 0)
            {
                EnemyDie();
            }
        }
        else
        {
            
        }
    }
    public void EnemyDie()
    {
        Destroy(this.gameObject);
    }
    public void SpriteChange(Sprite sprite)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
    }
}
