using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Animal : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject Coin;
    [SerializeField] private int moneyGive;

    private Animator animator;

    private void OnEnable()
    {
        EventBus.click += GiveMoney;
        StaticData.animals.Add(this);
    }

    private void OnDisable()
    {
        EventBus.click -= GiveMoney;
        StaticData.animals.Remove(this);
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        canvas = GetComponentInChildren<Canvas>();
    }

    void Start()
    {
        
    }

    private void GiveMoney()
    {
        StaticData.SetMoney(moneyGive);
    }
    
    public void PlayBounceAnim()
    {
        animator.Play("Bounce");
        GameObject coin = Instantiate(Coin, canvas.transform);
    }
}
