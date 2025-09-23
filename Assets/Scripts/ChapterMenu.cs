using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChapterMenu : MonoBehaviour
{

    public Button C1;
    public Button C2;
    public Button C3;
    public Button C4;
    public Button Back;
    // Start is called before the first frame update
    void Start()
    {
        C1.onClick.AddListener(Chapter1);
        C2.onClick.AddListener(Chapter2);
        //Those doesn't exists
        // C3.onClick.AddListener(Chapter3); 
        // C4.onClick.AddListener(Chapter4); 
        Back.onClick.AddListener(BackToMenu);
        int chaptersUnlocked = PlayerPrefs.GetInt("CHAPTER", 1);
        C1.interactable = chaptersUnlocked > 0;
        C2.interactable = chaptersUnlocked > 1;
        // C3.interactable = chaptersUnlocked > 2;
        // C4.interactable = chaptersUnlocked > 3;
    }

    void Chapter1()
    {
        SceneManager.LoadScene("LEVEL1");
    }
    void Chapter2()
    {
        SceneManager.LoadScene("LEVEL21");
    }
    void Chapter3()
    {

    }
    void Chapter4()
    {

    }
    void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
