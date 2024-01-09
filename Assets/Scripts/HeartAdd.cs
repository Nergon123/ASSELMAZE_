using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartAdd : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("hp", PlayerPrefs.GetInt("hp", 0) + 1);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
