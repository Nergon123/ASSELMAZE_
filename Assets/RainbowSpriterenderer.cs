using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowSpriterenderer : MonoBehaviour
{
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        sr.color = Random.ColorHSV();
    }
}
