using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineskin : MonoBehaviour
{
    
    // Start is called before the first frame update
   SpriteRenderer sr ;
    void Start()
    {
        
        sr = GetComponent<SpriteRenderer>();   
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (PlayerPrefs.GetString("rainbow") == "true")
        {
            if (collision.gameObject.tag == "Player")
            {
                sr.color = Random.ColorHSV();
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
    }
}
