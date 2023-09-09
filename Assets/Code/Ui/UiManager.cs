using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GuiPointerListener clickArea;
    [SerializeField] private GuiPointerListener exitShop;
    [SerializeField] private GuiPointerListener openShop;

    [SerializeField] private TMP_Text MoneyCount;

    

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

    private void Awake()
    {
        StaticData.SetMoney(100);
        Init();

        clickArea.OnClick += data => 
        {            
            int i = Random.Range(0, StaticData.animals.Count);
            StaticData.animals[i].PlayBounceAnim();
            EventBus.Click();
        };

        exitShop.OnClick += data => { EventBus.ShopClose(); };
        openShop.OnClick += data => { EventBus.ShopOpen(); };
    }

    private void Update()
    {
        Refresh();
    }

    private void Init()
    {
        MoneyCount.text = StaticData.GetMoney().ToString();
    }

    private void Refresh()
    {
        MoneyCount.text = StaticData.GetMoney().ToString();
    }
    
    
}
