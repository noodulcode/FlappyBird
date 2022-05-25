using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    private void OnEnable() 
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);  // give time, spawnrate
    }

    private void OnDisable() 
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn() // clone prefab
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity); // instantiate creates a new object and clones existing one. give it initial position and rotation. No need for rotation
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight); // adjusts position of pipes based on random variable
    }
}
