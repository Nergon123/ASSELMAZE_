using UnityEngine;

public class lineskin : MonoBehaviour
{

    // Start is called before the first frame update
    SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (PlayerPrefs.GetString("rainbow") == "true") // string as booleans... waste of data
        {
            if (collision.gameObject.tag == "Player")
            {
                sr.color = Random.ColorHSV();
            }
        }

    }
}
