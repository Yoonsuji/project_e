using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPower : MonoBehaviour
{
    public int enemyPower;
    public Text enemyPowerText;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
    }

    void Update()
    {
        enemyPowerText.text = enemyPower.ToString();
        if (enemyPower <= 0)
        {
            EnemyDie();
        }
    }
    void EnemyDie()
    {
        Destroy(this.gameObject);
    }
    public void SpriteChange(Sprite sprite)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
    }
}
