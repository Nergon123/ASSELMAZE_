using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotaterb : MonoBehaviour
{
    float angle;
    Rigidbody2D rb;
    public float rotatespeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.rotation = angle;
        angle= angle + rotatespeed;
        if(angle == 360)
        {
            angle = 0;
        }
    }
}
