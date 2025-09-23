using UnityEngine;

public class HeartAdd : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("hp", PlayerPrefs.GetInt("hp", 0) + 1);
            Destroy(gameObject);
        }
    }
}
