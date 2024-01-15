using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiMove : MonoBehaviour
{
    public Transform targetObject;
    public Camera camera;
    public Vector3 offset = new Vector3(0f, 0.5f, 0f);
    public TMP_Text squareText;
    private void Start()
    {
        if (targetObject != null && targetObject.gameObject.GetComponent<EnemyPower>() != null)
        {
            if (targetObject.gameObject.GetComponent<EnemyPower>() != null)
            {
                if (targetObject.gameObject.GetComponent<EnemyPower>().selectedType == EnemyPower.enemyType.item)
                {
                    this.GetComponent<TMP_Text>().outlineColor = new Color(80f, 0f, 255f, 255f);
                }
                else if (targetObject.gameObject.GetComponent<EnemyPower>().selectedType == EnemyPower.enemyType.multiplicationEnemy)
                {
                    int power = targetObject.gameObject.GetComponent<EnemyPower>().enemyPower;
                    this.GetComponent<TMP_Text>().text = "X" + power;
                }
                else if (targetObject.gameObject.GetComponent<EnemyPower>().selectedType == EnemyPower.enemyType.squareEnemy)
                {
                    offset = new Vector3(0.25f, 1f, 0f);
                    this.GetComponent<TMP_Text>().fontSize = 30f;
                    TMP_Text text = Instantiate(squareText, this.transform.position, Quaternion.identity);
                    text.transform.SetParent(transform, false);
                    text.transform.localPosition = new Vector3(-25f, -25f, 0f);
                }
                else if(targetObject.gameObject.GetComponent<EnemyPower>().selectedType == EnemyPower.enemyType.BossEnemy)
                {
                    offset = new Vector3(0f, 2f, 0f);
                    this.GetComponent<TMP_Text>().fontSize = 75f;
                }
            }
        }
    }
    void Update()
    {
        if (targetObject != null)
        {
            Vector3 targetPosition = targetObject.transform.position + offset;
            transform.position = Camera.main.WorldToScreenPoint(targetPosition);
        }
    }
}
