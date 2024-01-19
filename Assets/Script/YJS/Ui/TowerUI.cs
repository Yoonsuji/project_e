using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TowerUI : MonoBehaviour
{
    public Image ImageSprite;
    public Sprite stage12;
    public Sprite stage3;
    public TMP_Text text;
    public StagePrefab stagePrefab;
    private void Start()
    {
        if (stagePrefab.currentStage != 3)
        {
            text.text = "��� ���� óġ�ϼ���.";
            ImageSprite.sprite = stage12;
        }
        else
        {
            text.text = "������ óġ�ϼ���.";
            ImageSprite.sprite = stage3;
        }
    }
}
