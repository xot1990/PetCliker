using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticData
{
    public static List<FlourCube> flourCubes = new List<FlourCube>();
    public static List<Animal> animals = new List<Animal>();
    private static int value;

    public static void SetMoney(int count)
    {
        value += count;
    }

    public static int GetMoney()
    {
        return value;
    }
}
