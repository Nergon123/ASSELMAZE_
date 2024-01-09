using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerarandom : MonoBehaviour
{
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        StartCoroutine(Lol());
    }
    IEnumerator Lol(){
    while (true) {
    	yield return new WaitForSeconds(0.2f);
    	cam.backgroundColor = Random.ColorHSV();
    }
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
