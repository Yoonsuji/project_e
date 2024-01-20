using System.Collections;
using UnityEngine;

public class PetAi : MonoBehaviour
{
    public PetTarget petTarget;
    public float speed;
    public float waitTime;
    public bool isMove;
    public float originalScale;
    public Transform targetImage;

    private void Start()
    {
        petTarget.ChangeTransform();
    }
    void Update()
    {
        if (isMove == true)
        {
            this.GetComponent<Animator>().SetBool("isMove", true);
            if (targetImage != null)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, targetImage.position, step);
                if (this.transform.position == targetImage.position)
                {
                    isMove = false;
                    Invoke("TransLateTarget", waitTime);
                }
                if (targetImage.position.x <= this.transform.position.x)
                {
                    RectTransform rectTransform = GetComponent<RectTransform>();
                    Vector3 currentScale = rectTransform.localScale;
                    currentScale.x = -originalScale;
                    rectTransform.localScale = currentScale;
                }
                else
                {
                    RectTransform rectTransform = GetComponent<RectTransform>();
                    Vector3 currentScale = rectTransform.localScale;
                    currentScale.x = originalScale;
                    rectTransform.localScale = currentScale;
                }
            }
        }
        else
        {
            this.GetComponent<Animator>().SetBool("isMove", false);
        }
    }
    void TransLateTarget()
    {
        petTarget.ChangeTransform();
        isMove = true;
    }
}