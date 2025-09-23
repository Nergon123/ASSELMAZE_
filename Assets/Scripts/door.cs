using UnityEngine;
using UnityEngine.UI;
public class door : MonoBehaviour
{
    public GameObject dialog;
    public Text input;
    public Button exit;
    public Button accept;
    public Button[] numbers;
    public string password;
    AudioSource source;
    public AudioClip beep;
    public AudioClip error;
    public AudioClip correct;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

        for (int i = 0; i < numbers.Length; i++)
        {
            int closureIndex = i; // Prevents the closure problem
            numbers[closureIndex].onClick.AddListener(() => TaskOnClick(closureIndex));
        }

        dialog.SetActive(false);
        exit.onClick.AddListener(quit);
        accept.onClick.AddListener(acept);
    }
    void acept()
    {

        if (input.text == PlayerPrefs.GetInt("password").ToString())
        {
            source.PlayOneShot(error);
            Time.timeScale = 1.0f;
            Destroy(gameObject);
        }
        else
        {
            input.text = "ERROR";
            password = "";
            source.PlayOneShot(error);
        }
    }
    void TaskOnClick(int button)
    {
        password += button.ToString();
        input.text = password;
        source.PlayOneShot(beep);
    }
    void quit()
    {
        password = "";
        dialog.SetActive(false);
        Time.timeScale = 1f;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialog.SetActive(true);
            Time.timeScale = 0f;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            dialog.SetActive(false);
            Time.timeScale = 1f;

        }
    }
}
