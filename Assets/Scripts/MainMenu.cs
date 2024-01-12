using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button SNG, Continue, rateGame, Settings, Quit;

    // Start is called before the first frame update
    void Start()
    {

        SNG.onClick.AddListener(NGLIST);
        Continue.onClick.AddListener(CNLIST);
        rateGame.onClick.AddListener(RBLIST);
        Settings.onClick.AddListener(STLIST);
        Quit.onClick.AddListener(Application.Quit);

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
