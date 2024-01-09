using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button SNG, Continue, rateGame, Settings, Quit, telegram;

    // Start is called before the first frame update
    void Start()
    {
        
      
        telegram.onClick.AddListener(telega);
        SNG.onClick.AddListener(NGLIST);
        Continue.onClick.AddListener(CNLIST);
        rateGame.onClick.AddListener(RBLIST);
        Settings.onClick.AddListener(STLIST);
        Quit.onClick.AddListener(Application.Quit);
        switch (Application.systemLanguage)
        {
            case SystemLanguage.Russian:
                SNG.GetComponentInChildren<Text>().text = "Новая игра";
                Continue.GetComponentInChildren<Text>().text = "Продолжить";
                rateGame.GetComponentInChildren<Text>().text = "Оценить игру";
                Settings.GetComponentInChildren<Text>().text = "Настройки";
                Quit.GetComponentInChildren<Text>().text = "Выйти";
                break;
            case SystemLanguage.Ukrainian:
                SNG.GetComponentInChildren<Text>().text = "Нова гра";
                Continue.GetComponentInChildren<Text>().text = "Продовжити";
                rateGame.GetComponentInChildren<Text>().text = "Оцінити гру";
                Settings.GetComponentInChildren<Text>().text = "Налаштування";
                Quit.GetComponentInChildren<Text>().text = "Вихід";
                break;
            default:
                SNG.GetComponentInChildren<Text>().text = "New Game";
                Continue.GetComponentInChildren<Text>().text = "Continue";
                rateGame.GetComponentInChildren<Text>().text = "Rate game";
                Settings.GetComponentInChildren<Text>().text = "Settings";
                Quit.GetComponentInChildren<Text>().text = "Exit";
                break;
        }
    }


    void telega()
    {
        Application.OpenURL("https://t.me/joinchat/M07FXExnAG0tqZjyyeftgA");
    }
    void NGLIST()
    {
        SceneManager.LoadScene("Chapters");
    }
    void CNLIST()
    {
        int Level;
        Level = PlayerPrefs.GetInt("LEVEL");
        SceneManager.LoadScene("LEVEL" + Level.ToString());
    }
    void STLIST()
    {
        SceneManager.LoadScene("Settings");
    }

    void ABLIST()
    {
        SceneManager.LoadScene("About");
    }
    void RBLIST()
    {
        //Rate a app
        Application.OpenURL("market://details?id=com.pandd.AccelMaze");
    }

    // Update is called once per frame
    void Update()
    {
        // Check if Back was pressed this frame
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            // Quit the application
            Application.Quit();
        }
    }
}
