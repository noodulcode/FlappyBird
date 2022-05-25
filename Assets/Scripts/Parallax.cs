using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour // need to get a refernce to our mesh renderer
{
    private MeshRenderer meshRenderer;
    public float animationSpeed = 1f;

    private void Awake() 
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update() // change offset on material repeatedly 
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0); // not moving in y, only moving in x
    }
}
