using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class controller : MonoBehaviour
{

    public bool m_binvCtrls = false;
    public SpriteRenderer sr;
    public Sprite def;
    public Sprite pizza;
    public Vector3 camLocation1;
    public Vector3 camLocation2;
    public Vector3 camLocation3;
    public Vector2 PlyLocation1;
    public Vector2 PlyLocation2;
    public Vector2 PlyLocation3;

    public Rigidbody2D m_rbMain;
    public float m_fSpeed = 1f;
    public GameObject Finish;
    public GameObject Key;
    public GameObject win;
    public int numberOfLevel;
    AudioSource source;
    public AudioClip clip;
    public AudioClip clipkick;
    public bool haskey = false;

    private Vector2 m_vk2MoveVector;
    void Start()
    {
        m_rbMain = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();

        SkinManager.SetPlayerSkin(sr);

        if (PlayerPrefs.GetInt("LEVEL") < numberOfLevel)
        {
            PlayerPrefs.SetInt("LEVEL", numberOfLevel);
        }

        Finish.SetActive(false);

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            source.PlayOneShot(clipkick, 1f);
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        var Hp = PlayerPrefs.GetInt("hp");
        var coins = PlayerPrefs.GetInt("coins");

        if (other.gameObject.tag == "InvertControls")
        {
            m_binvCtrls = true;
        }
        if (other.gameObject.tag == "health")
        {
            PlayerPrefs.SetInt("hp", Hp++);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Finish")
        {
            Time.timeScale = 0;
            win.SetActive(true);
        }
        if (other.gameObject.tag == "key")
        {
            haskey = true;
            linetoggle[] toggles = GameObject.FindObjectsByType<linetoggle>(FindObjectsSortMode.InstanceID);
            foreach (linetoggle toggle in toggles)
            {
                toggle.setHasKey(haskey);
            }
            Finish.SetActive(true);
            Key.SetActive(false);
        }
        if (other.gameObject.tag == "NextOne")
        {
            Camera.main.transform.position = camLocation2;
            m_rbMain.transform.position = PlyLocation2;
        }
        if (other.gameObject.tag == "PrevOne")
        {
            Camera.main.transform.position = camLocation1;
            m_rbMain.transform.position = PlyLocation1;
        }

        if (other.gameObject.tag == "enemy")
        {
            Hp--;

            PlayerPrefs.SetInt("hp", Hp);

            if (Hp < 0)
            {
                PlayerPrefs.SetInt("LEVEL", 1);
                SceneManager.LoadScene("LEVEL1");
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (other.gameObject.tag == "coin")
        {
            source.PlayOneShot(clip);
            coins++;
            PlayerPrefs.SetInt("coins", coins);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Switch")
        {
            other.GetComponent<Switch>().status = true;

        }
        if (other.gameObject.tag == "SwitchDouble")
        {
            other.GetComponent<SwitchDouble>().status = true;

        }
    }



    void Update()
    {
        CheckMove();
    }
    private void FixedUpdate()
    {
        m_rbMain.AddForce(m_vk2MoveVector * Time.deltaTime);
    }
    public void CheckMove()
    {
        float moveHorizontal;
        float moveVertical;
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
        }
        else
        {
            moveHorizontal = Input.acceleration.x;
            moveVertical = Input.acceleration.y;
        }
        if (m_binvCtrls)
            m_vk2MoveVector = new Vector2(-moveHorizontal, -moveVertical).normalized * m_fSpeed;
        else
            m_vk2MoveVector = new Vector2(moveHorizontal, moveVertical).normalized * m_fSpeed;
    }
}