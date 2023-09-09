using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private GuiPointerListener listener;
    [SerializeField] private TMP_Text Count;
    [SerializeField] private TMP_Text Price;
    [SerializeField] private TMP_Text Name;
    [SerializeField] private GameObject Block;
    [Header("Settings")]
    [SerializeField] private int price;
    [SerializeField] private string animalName;
    [SerializeField] private GameObject AnimalSpawn;

    private Type type;

    private int count;

    private void OnEnable()
    {
        EventBus.shopInit += Init;
        EventBus.shopClose += ClearStats;
        EventBus.shopClick += CheckMoney;
    }
    private void OnDisable()
    {
        EventBus.shopInit -= Init;
        EventBus.shopClose -= ClearStats;
        EventBus.shopClick -= CheckMoney;
    }

    private void Awake()
    {
        type = AnimalSpawn.GetComponent<Animal>().GetType();
        listener.OnClick += data => 
        {
            StaticData.SetMoney(-price);

            if (price > StaticData.GetMoney())
                Block.SetActive(true);

            count++;
            Refresh();
            EventBus.ShopClick(AnimalSpawn);
        };
    }

    void Start()
    {
        Init();
    }

    private void ClearStats()
    {
        count = 0;
    }

    private void CheckMoney(GameObject gameObject)
    {
        if (price > StaticData.GetMoney())
            Block.SetActive(true);
    }

    private void Refresh()
    {
        Count.text = count.ToString();
    }

    private void Init()
    {
        if (price > StaticData.GetMoney())
            Block.SetActive(true);
        else Block.SetActive(false);

        Price.text = price.ToString();
        Name.text = animalName;

        foreach(var A in StaticData.animals)
        {
            if (A.GetType() == type)
                count++;
        }

        Count.text = count.ToString();
    }
}
