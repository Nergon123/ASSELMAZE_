using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDouble : MonoBehaviour
{
	public GameObject switchDoor;
	public GameObject switchDoor2;
	AudioSource audioSource;
	public AudioClip AC;
	SpriteRenderer sr;
	public Sprite off;
	public Sprite on;
	public bool status;
	bool CoroutineIsStarted = false;
	
    // Start is called before the first frame update
    void Start()
    {
    	audioSource = GetComponent<AudioSource>();
    	sr = GetComponent<SpriteRenderer>();
    	sr.sprite = off;
    	status = false;
    }
    IEnumerator Coroutine(){
    CoroutineIsStarted = true;
    sr.sprite= on;
    status = true;
    switchDoor.SetActive(false);
    switchDoor2.SetActive(true);
    audioSource.PlayOneShot(AC,1f);
    yield return new WaitForSeconds(10);
    switchDoor.SetActive(true);
    switchDoor2.SetActive(false);
    audioSource.Stop();
    status = false;
    sr.sprite = off;
    CoroutineIsStarted = false;

    }
    // Update is called once per frame
    void Update()
    {
    	
    	if(status == true){
    		if(CoroutineIsStarted == false){
    			StartCoroutine(Coroutine());  
    		}
    	}
    }
}
