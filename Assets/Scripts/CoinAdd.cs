using UnityEngine;

public class CoinAdd : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + 1);

            Destroy(gameObject);

        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
