using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Image))]
public class Coin : MonoBehaviour
{
    private Image image;
    private RectTransform rectTransform;

    private void Awake()
    {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }

    void Start()
    {
        DOTween.Sequence()
            .Append(rectTransform.DOAnchorPosY(2,1))
            .AppendCallback(Kill);

        image.DOFade(0, 1);
    }

    private void Kill()
    {
        Destroy(gameObject);
    }
   
}
