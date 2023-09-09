using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlourCube : MonoBehaviour
{    
    [SerializeField] private Transform SpawnPoint;

    [SerializeField] private GameObject VFX;

    public bool isEmpty = true;

    private void OnEnable()
    {
        StaticData.flourCubes.Add(this);
    }

    private void OnDisable()
    {
        StaticData.flourCubes.Remove(this);
    }

    void Start()
    {
        
    }

    public void Spawn(GameObject Inst)
    {
        isEmpty = false;
        GameObject Pet = Instantiate(Inst);
        Pet.transform.position = SpawnPoint.position;
        GameObject vfx = Instantiate(VFX);
        vfx.transform.position = SpawnPoint.position;
    }
}
