using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyPower : MonoBehaviour
{
    public int enemyPower;
    public List<RuntimeAnimatorController> EnemyAnimations = new List<RuntimeAnimatorController>();
    public Sprite square;
    public Sprite Boss;
    public Sprite plus;
    public Sprite minus;
    public bool type;
    public TMP_Text enemyPowerText;
    private SpriteRenderer spriteRenderer;
    private PlayerScript player;
    public enum enemyType
    {
        nolmalEnemy, BossEnemy, item, multiplicationEnemy, squareEnemy
    }
    public enemyType selectedType;
    void Start()
    {
        if (selectedType == enemyType.multiplicationEnemy)
        {
            enemyPowerText.text = enemyPower.ToString();
        }
        enemyPowerText.text = enemyPower.ToString();
        player = PlayerScript.FindObjectOfType<PlayerScript>();
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
            this.GetComponent<Animator>().runtimeAnimatorController = EnemyAnimations[0];
        }
        else if (selectedType == enemyType.multiplicationEnemy)
        {
            this.GetComponent<Animator>().runtimeAnimatorController = EnemyAnimations[1];
        }
        else if (selectedType == enemyType.squareEnemy)
        {
            this.GetComponent<Animator>().runtimeAnimatorController = EnemyAnimations[2];
        }
        else if (selectedType == enemyType.BossEnemy)
        {
            this.GetComponent<Animator>().runtimeAnimatorController = EnemyAnimations[3];
            this.transform.position = new Vector3(this.transform.position.x, -1.1f, 0f);
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
        if (type == false)
        {
            if (enemyPower <= 0)
            {
                EnemyDie();
            }
        }
    }
    public void ChangeAttackAnime()
    {
        player.AttackAnime(true);
        this.GetComponent<Animator>().SetBool("Attack", true);
    }
    public void EnemyDie()
    {
        player.AttackAnime(false);
        Destroy(this.gameObject);
    }
    public void SpriteChange(Sprite sprite)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
    }
}
