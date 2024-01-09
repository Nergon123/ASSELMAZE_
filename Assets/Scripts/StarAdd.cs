using UnityEngine;

public class StarAdd : MonoBehaviour
{
    public string LevelNow;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch (PlayerPrefs.GetInt(LevelNow))
            {
                case 0:
                    PlayerPrefs.SetInt(LevelNow, 1);
                    break;
                case 1:
                    PlayerPrefs.SetInt(LevelNow, 2);
                    break;
                case 2:
                    PlayerPrefs.SetInt(LevelNow, 3);
                    break;
                case 3:
                    break;

            }

            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
