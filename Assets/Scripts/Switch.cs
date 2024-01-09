using System.Collections;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject switchDoor;
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
    IEnumerator Coroutine()
    {
        CoroutineIsStarted = true;
        sr.sprite = on;
        status = true;
        switchDoor.SetActive(false);
        audioSource.PlayOneShot(AC, 1f);
        yield return new WaitForSeconds(10);
        switchDoor.SetActive(true);
        audioSource.Stop();
        status = false;
        sr.sprite = off;
        CoroutineIsStarted = false;

    }
    // Update is called once per frame
    void Update()
    {

        if (status == true)
        {
            if (CoroutineIsStarted == false)
            {
                StartCoroutine(Coroutine());
            }
        }
    }
}
