using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Level : MonoBehaviour
{
    public Text text;
    public string nextLevel;
    public GameObject Finish;
    public Button Next;
    public Button Menu;
    public GameObject MenuDialog;
    //Menu 
    public Button Continue;
    public Button MainMenu;
    public Button ExitGame;
    public Button NextLevelad;

    public bool endOfChapter = false;

    public int NextChapter;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("pause", "false");
        NextLevelad.interactable = false;
        //GameObjects
        Finish.SetActive(false);
        MenuDialog.SetActive(false);
        // Buttons
        Next.onClick.AddListener(Nxt);
        Menu.onClick.AddListener(Mn);
        ExitGame.onClick.AddListener(ext);
        MainMenu.onClick.AddListener(Men);
        Continue.onClick.AddListener(Contn);
        NextLevelad.onClick.AddListener(NextLevel);
    }
    void NextLevel()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetString("pause", "false"); // THIS is terrible but I fear that if I change that I can break something. I don't really remember anything from here
        SceneManager.LoadScene(nextLevel);
    }

    void Contn()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetString("pause", "false");
        MenuDialog.SetActive(false);
    }
    void ext()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetString("pause", "false");
        Application.Quit();
    }
    void Men()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetString("pause", "false");
        SceneManager.LoadScene("Menu");
    }

    void Nxt()
    {
        if (endOfChapter == true)
        {
            PlayerPrefs.SetInt("CHAPTER", NextChapter);
        }
        Time.timeScale = 1;
        SceneManager.LoadScene(nextLevel);
    }
    void Mn()
    {
        MenuDialog.SetActive(true);
        Time.timeScale = 0;
        PlayerPrefs.SetString("pause", "true");
    }
}
