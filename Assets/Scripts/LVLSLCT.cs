using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LVLSLCT : MonoBehaviour
{
    public Button Bn1;
    public Button Bn2;
    public Button Bn3;
    public Button Bn4;
    public Button Bn5;
    public Button BACK;
    // Start is called before the first frame update
    void Start()
    {
        Button B1 = Bn1.GetComponent<Button>();
        Button B2 = Bn2.GetComponent<Button>();
        Button B3 = Bn3.GetComponent<Button>();
        Button B4 = Bn4.GetComponent<Button>();
        Button B5 = Bn5.GetComponent<Button>();
        Button Back = BACK.GetComponent<Button>();
        Back.onClick.AddListener(Backl);
        B5.onClick.AddListener(Btn5);
        B4.onClick.AddListener(Btn4);
        B3.onClick.AddListener(Btn3);
        B2.onClick.AddListener(Btn2);
        B1.onClick.AddListener(Btn1);
        int lvl = PlayerPrefs.GetInt("LEVEL");
        B1.interactable = lvl >= 0;
        B2.interactable = lvl >= 1;
        B3.interactable = lvl >= 2;
        B4.interactable = lvl >= 3;
        B5.interactable = lvl >= 4;
    }
    void Btn5()
    {
        SceneManager.LoadScene("LEVEL5");
    }
    void Btn4()
    {
        SceneManager.LoadScene("LEVEL4");
    }
    void Btn3()
    {
        SceneManager.LoadScene("LEVEL3");
    }
    void Btn2()
    {
        SceneManager.LoadScene("LEVEL2");
    }
    void Btn1()
    {
        SceneManager.LoadScene("LEVEL1");
    }
    void Backl()
    {
        SceneManager.LoadScene("MENU");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Backl();
        }
    }
}
