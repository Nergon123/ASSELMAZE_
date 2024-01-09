using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop1 : MonoBehaviour
{
    [SerializeField] private Button[] m_bBuy;
    [SerializeField] private int[] m_iId, m_iCost;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        SetButton();
    }

    public void bck()
    {
        SceneManager.LoadScene("Menu");
    }

    public void defl()
    {
        PlayerPrefs.SetInt("skin", 0);
        text.text = "Success";
    }

    void Buy(int skin, int cost)
    {
        if (PlayerPrefs.GetInt("skin" + skin.ToString(), 0) != 1)
        {
            if (PlayerPrefs.GetInt("coins") > cost - 1)
            {
                PlayerPrefs.SetInt("skin", skin);
                PlayerPrefs.SetInt("skin" + skin.ToString(), 1);
                PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - cost);
                text.text = "Success";
            }
            else
            {
                text.text = "Not Enough coins";
            }
        }
        else
        {
            PlayerPrefs.SetInt("skin", skin);
            text.text = "Success";
        }
    }

    void SetButton()
    {
        for (int i = 0; i < m_bBuy.Length; i++)
        {
            int x = i;
            m_bBuy[x].onClick.AddListener(delegate { Buy(m_iId[x], m_iCost[x]); });
        }
    }

}
