using UnityEngine;

public class StarAdd : MonoBehaviour
{
    public string LevelNow;
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            int stars = PlayerPrefs.GetInt(LevelNow);
            PlayerPrefs.SetInt(LevelNow, stars >= 0 && stars <= 3 ? stars + 1 : stars);
            Destroy(gameObject);
        }
    }
}
