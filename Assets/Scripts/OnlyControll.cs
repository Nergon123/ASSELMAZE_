using UnityEngine;
using UnityEngine.SceneManagement;

public class OnlyControll : MonoBehaviour
{
    public float m_fSpeed = 0.05f;
    Rigidbody2D m_rbMain;
    private Vector2 m_vk2MoveVector;
    void Start()
    {
        m_rbMain = GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "shop")
        {
            SceneManager.LoadScene("shop");
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
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
        float moveHorizontal = 0;
        float moveVertical = 0;
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
        m_vk2MoveVector = new Vector2(moveHorizontal, moveVertical).normalized * m_fSpeed;
    }
}
