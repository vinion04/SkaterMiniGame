using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    private float backgroundSpeed = 0.3f;   //slow to start
    public SpriteRenderer backgroundRenderer;

    void Update()
    {
        //USED FROM TUTORIAL
        backgroundRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0f);
    }
}
