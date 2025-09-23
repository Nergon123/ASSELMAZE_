using UnityEngine;
using UnityEngine.UI;
public class passwordRandom : MonoBehaviour
{
    public GameObject dialog;
    public Text passwordText;
    // Start is called before the first frame update
    void Start()
    {
        dialog.SetActive(false);
        PlayerPrefs.SetInt("password", Random.Range(100000, 999999));
        passwordText.text = "Password :\n" + PlayerPrefs.GetInt("password").ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dialog.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dialog.SetActive(false);
        }
    }
}
