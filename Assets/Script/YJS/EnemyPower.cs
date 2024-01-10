using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyPower : MonoBehaviour
{
    public int enemyPower;
    public List<RuntimeAnimatorController> StopAnimations = new List<RuntimeAnimatorController>();
    public Sprite square;
    public Sprite Boss;
    public Sprite plus;
    public Sprite minus;
    public bool type;
    public TMP_Text enemyPowerText;
    private SpriteRenderer spriteRenderer;
    public enum enemyType
    {
        nolmalEnemy, BossEnemy, item, multiplicationEnemy, squareEnemy
    }
    public enemyType selectedType;
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
        if (selectedType == enemyType.nolmalEnemy)
        {
            this.GetComponent<Animator>().runtimeAnimatorController = StopAnimations[0];
        }
        else if (selectedType == enemyType.multiplicationEnemy)
        {
            this.GetComponent<Animator>().runtimeAnimatorController = StopAnimations[1];
        }
        else if (selectedType == enemyType.squareEnemy)
        {
            this.GetComponent<Animator>().runtimeAnimatorController = StopAnimations[2];
        }
        else if (selectedType == enemyType.BossEnemy)
        {
            SpriteChange(Boss);
        }
        else if (selectedType == enemyType.item)
        {
            if (enemyPower > 0)
            {
                SpriteChange(plus);
            }
            else
            {
                SpriteChange(minus);
            }
        }
    }

    void Update()
    {
        if (selectedType == enemyType.multiplicationEnemy)
        {
            enemyPowerText.text = enemyPower.ToString();
        }
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
