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
    public bool _status;

    private Coroutine m_crMain;
    public bool status
    {
        get => _status;
        set
        {
            _status = value;
            if (_status && m_crMain == null)
                m_crMain = StartCoroutine(Coroutine());
        }
    }

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
        sr.sprite = on;
        switchDoor.SetActive(false);
        audioSource.PlayOneShot(AC, 1f);
        yield return new WaitForSeconds(10);
        switchDoor.SetActive(true);
        audioSource.Stop();
        sr.sprite = off;
        m_crMain = null;
        status = false;
    }
    // Update is called once per fram
}
