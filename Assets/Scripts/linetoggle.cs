using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linetoggle : MonoBehaviour
{
	SpriteRenderer sr;
	BoxCollider2D BC2D;
	public bool AfterKey;
    // Start is called before the first frame update
    void Start()
    {
    	sr = GetComponent<SpriteRenderer>();
    	BC2D = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
    	if(GameObject.FindGameObjectWithTag("Player").GetComponent<controller>().haskey == true){
    		if(AfterKey == true){
    			sr.enabled = false;
    			BC2D.enabled = false;
    		}else{
    			sr.enabled = true;
    			BC2D.enabled = true;
    		}
    	}else{
    		if(AfterKey == true){
    			sr.enabled = true;
    			BC2D.enabled = true;
    		}else{
    			sr.enabled = false;
    			BC2D.enabled = false;
    		}
    	}
    }
}
