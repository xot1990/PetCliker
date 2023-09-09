using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Shop : MonoBehaviour
{

    private void OnEnable()
    {
        EventBus.shopClose += Close;
        EventBus.shopOpen += Open;
    }

    private void OnDisable()
    {
        EventBus.shopClose -= Close;
        EventBus.shopOpen -= Open;
    }

    private void Awake()
    {
        
    }

    private void Close()
    {
        DOTween.Sequence()
            .Append(transform.DOScale(0, 0.5f))
            .AppendCallback(EventBus.Spawn);        
    }

    private void Open()
    {
        EventBus.ShopInit();

        DOTween.Sequence()
            .Append(transform.DOScale(1.2f, 0.3f))
            .Append(transform.DOScale(0.8f, 0.2f))
            .Append(transform.DOScale(1f, 0.1f));
    }
    
}
