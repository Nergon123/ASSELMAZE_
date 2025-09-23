using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Controll3D : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 1f;
    public string levelNow;
    public int numberOfLevel;
    public Button Next;
    public GameObject win;
    public GameObject Finish;
    public GameObject Key;
    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.GetInt("LEVEL") < numberOfLevel)
        {
            PlayerPrefs.SetInt("LEVEL", numberOfLevel);
        }
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "key")
        {
            Debug.Log("ENTER");
            Finish.SetActive(true);
            Key.SetActive(false);
        }
        if (other.gameObject.tag == "Finish")
        {
            Next.interactable = true;
            Time.timeScale = 0.0f;
            win.SetActive(true);

        }
        if (other.gameObject.tag == "enemy")
        {
            SceneManager.LoadScene(levelNow);
            PlayerPrefs.SetInt("hp", PlayerPrefs.GetInt("hp") - 1);
            if (PlayerPrefs.GetInt("hp") < 0)
            {

                switch (PlayerPrefs.GetInt("CHAPTER", 1))
                {
                    case 1:
                        SceneManager.LoadScene("LEVEL1");
                        PlayerPrefs.SetInt("LEVEL", 1);
                        break;
                    case 2:
                        SceneManager.LoadScene("LEVEL21");
                        PlayerPrefs.SetInt("LEVEL", 22);
                        break;
                }

            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            //start of movement code from rollerball tutorial
            //used for desktop movement
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movemen = new Vector3(moveHorizontal, 0, moveVertical);

            rb.AddForce(movemen * speed * Time.deltaTime);
            //end of movement code from rollerball tutorial
        }
        Vector3 movement = new Vector3(Input.acceleration.x, 0, Input.acceleration.y);
        rb.AddForce(movement * speed * Time.deltaTime);
    }
}

