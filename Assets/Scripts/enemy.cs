using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public bool vertical;
    Vector2 move;
	
    // Start is called before the first frame update
    void Start()
    {
        if(vertical == true)
        {
            move = Vector2.up;
        }
        else
        {
            move = Vector2.right;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    { 
        if(other.gameObject.tag == "enemyup") {
            if(vertical == true)
            {
                move = Vector2.up;
            }
            else
            {
                move = Vector2.right;
            }
        }
        if(other.gameObject.tag == "enemydown")
        {
            if(vertical == true)
            {
                move = Vector2.down;
            }
            if(vertical == false)
            {
                move = Vector2.left;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("hp") < 0)
        {
            PlayerPrefs.SetInt("LEVEL", 1);
            SceneManager.LoadScene("LEVEL1");

        }
        rb.MovePosition(rb.position + move*speed);
    }
}
