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

        switch (PlayerPrefs.GetInt("LEVEL"))
        {
            case 0:
                B1.interactable = true;
                B2.interactable = false;
                B3.interactable = false;
                B4.interactable = false;
                B5.interactable = false;
                break;
            case 1:
                B1.interactable = true;
                B2.interactable = true;
                B3.interactable = false;
                B4.interactable = false;
                B5.interactable = false;
                break;
            case 2:
                B1.interactable = true;
                B2.interactable = true;
                B3.interactable = true;
                B4.interactable = false;
                B5.interactable = false;
                break;
            case 3:
                B1.interactable = true;
                B2.interactable = true;
                B3.interactable = true;
                B4.interactable = true;
                B5.interactable = false;
                break;
            case 4:
                B1.interactable = true;
                B2.interactable = true;
                B3.interactable = true;
                B4.interactable = true;
                B5.interactable = true;
                break;

        }
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
        // Check if Back was pressed this frame
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            // Quit the application
            Backl();
        }
    }
}
