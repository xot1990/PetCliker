using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public static class EventBus
{
    public static Action<GameObject> shopClick;
    public static Action spawn;
    public static Action shopClose;
    public static Action shopOpen;
    public static Action shopInit;
    public static Action click;

    public static void Click()
    {
        click?.Invoke();
    }

    public static void ShopInit()
    {
        shopInit?.Invoke();
    }

    public static void ShopOpen()
    {
        shopOpen?.Invoke();
    }

    public static void ShopClose()
    {
        shopClose?.Invoke();
    }

    public static void ShopClick(GameObject gameObject)
    {
        shopClick?.Invoke(gameObject);
    }

    public static void Spawn()
    {
        spawn?.Invoke();
    }
}
