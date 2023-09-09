using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    private List<GameObject> spawnList = new List<GameObject>();

    private void OnEnable()
    {
        EventBus.shopClick += CollectToSpawn;
        EventBus.spawn += Spawn;
    }

    private void OnDisable()
    {
        EventBus.shopClick -= CollectToSpawn;
        EventBus.spawn -= Spawn;
    }
    
    private void CollectToSpawn(GameObject gameObject)
    {
        spawnList.Add(gameObject);
    }

    private void Spawn()
    {
        foreach (var G in spawnList)
        {
            SpawnInRandomCube(G);
        }

        spawnList.Clear();
    }

    private void SpawnInRandomCube(GameObject gameObject)
    {
        int FindLimit = 2000;
        int i = Random.Range(0, StaticData.flourCubes.Count);

        while (!StaticData.flourCubes[i].isEmpty)
        {
            FindLimit--;
            if (FindLimit <= 0)
                return;

            i = Random.Range(0, StaticData.flourCubes.Count);

        }

        StaticData.flourCubes[i].Spawn(gameObject);
    }
}
