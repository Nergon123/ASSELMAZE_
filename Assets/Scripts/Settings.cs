using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private Button Back, Reset, Close, Yes, No;
    [SerializeField]
    private GameObject Dialog;

    void Start()
    {
        if (Reset)
            Reset.onClick.AddListener(RST);
        if (Back)
            Back.onClick.AddListener(Bck);
        if (Close)
            Close.onClick.AddListener(CLS);
        if (Yes)
            Yes.onClick.AddListener(YS);
        if (No)
            No.onClick.AddListener(N);
    }
    void RST()
    {
        Dialog.SetActive(true);

    }
    void Bck()
    {
        SceneManager.LoadScene("Menu");
    }
    void CLS()
    {
        Dialog.SetActive(false);
    }
    void YS()
    {
        PlayerPrefs.SetInt("LEVEL", 0);
        PlayerPrefs.SetInt("coins", 0);
        PlayerPrefs.SetInt("skin", 0);
        Dialog.SetActive(false);
    }
    void N()
    {
        CLS();
    }
    // Update is called once per frame
    void Update()
    {
        // Check if back was pressed this frame
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Quit the application
            Bck();
        }
    }
}
