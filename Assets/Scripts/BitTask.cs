using UnityEngine;
using UnityEngine.UI;
public class BitTask : MonoBehaviour
{
    public GameObject window;
    public GameObject gate;
    public Button[] bits;
    public Button close;
    public Text status;
    public Text[] bitsText;
    public byte user;
    byte target;
    // Start is called before the first frame update
    void Start()
    {
        close.onClick.AddListener(delegate { window.SetActive(false); Time.timeScale = 1.0f; });
        for (int i = 0; i < 8; i++)
        {
            int closureIndex = i;
            bits[i].onClick.AddListener(delegate
            {
                user ^= (byte)((1 << 7) >> closureIndex);
                output();
            });
        }
        target = (byte)Random.Range(1, 0xFF);
        output();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Time.timeScale = 0.0f;
            window.SetActive(true);
        }
    }

    void output()
    {
        status.text = "Current:" + user.ToString() + "\nTarget:" + target.ToString();
        for (int i = 0; i < 8; i++)
        {
            bits[i].GetComponentInChildren<Text>().text = ((user & ((1 << 7) >> i)) != 0) ? "1" : "0";
        }

        if (user == target)
        {
            window.SetActive(false);
            gate.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
