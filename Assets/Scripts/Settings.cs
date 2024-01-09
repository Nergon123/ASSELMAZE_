using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private Button Back, Reset, Close, Yes, No;
    [SerializeField]
    private GameObject Dialog;
    private Toggle Wall;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Reset != null)
            Reset.onClick.AddListener(RST);
        if (Back != null)
            Back.onClick.AddListener(Bck);
        if (Close != null)
            Close.onClick.AddListener(CLS);
        if (Yes != null)
            Yes.onClick.AddListener(YS);
        if (No != null)
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
        if(Wall != null)
        {
            if (Wall.isOn == true) PlayerPrefs.SetString("rainbow", "true");
            else PlayerPrefs.SetString("rainbow", "false");

            if (PlayerPrefs.GetString("rainbow") == "true") Wall.isOn = true;
            else Wall.isOn = false;
        }
    }
}
