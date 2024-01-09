 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;


public class Level : MonoBehaviour,IUnityAdsListener
{
    public GameObject win;
    public GameObject keyInInterface;
    public GameObject AdResultObj;
    public Text AdResult;
    public Text text;
    public string nextLevel;
    public GameObject Finish;
    public GameObject Key;
    public Button Next;
    public Button Menu;
    public GameObject MenuDialog;
    //Menu 
    public Button Continue;
    int ad;
    public Button MainMenu;
    public Button ExitGame;
    public Button NextLevelad;
    string showresult;
    string gameId = "3550400";
    string myPlacementId = "rewardedVideo";
    public Button AdOk;
    public bool Ad = false;
    public bool endOfChapter = false;
    public int NextChapter;
    int numberoflevel = 0;
    string mmenu;
    string menu;
    string cntinue;
    string lvl;
    string exitg;
    string reklama;
    string lvlcmplt;
    // Start is called before the first frame update
    void Start()
    {
        
        PlayerPrefs.SetString("pause", "false");
        NextLevelad.interactable = false;
        Advertisement.AddListener(this);
        //GameObjects
        Finish.SetActive(false);
        MenuDialog.SetActive(false);
        // Buttons
        Next.onClick.AddListener(Nxt);
        Menu.onClick.AddListener(Mn);
        Next.interactable = false;
        ExitGame.onClick.AddListener(ext);
        MainMenu.onClick.AddListener(Men);
        Continue.onClick.AddListener(Contn);
        NextLevelad.onClick.AddListener(NextLevel);
        ad = 0;
        AdOk.onClick.AddListener(adok);
        keyInInterface.SetActive(false);
        numberoflevel = int.Parse(nextLevel.Replace("LEVEL","")) - 1;
        switch (Application.systemLanguage)
        {
            case SystemLanguage.Russian:
                menu = "Меню";
                cntinue = "Продолжить";
                lvl = "Уровень";
                exitg = "Выйти из игры!"; 
                reklama = "Пропустить уровень";
                mmenu = "Главное меню";
                lvlcmplt = "Уровень пройден";
                break;
            case SystemLanguage.Ukrainian:
                menu = "Меню";
                cntinue = "Продовжити";
                lvl = "Рівень";
                exitg = "Вийти з гри";
                reklama = "Пропустити рівень";
                mmenu = "Головне Меню";
                lvlcmplt = "Рівень пройдений";
                break;
            default:
                menu = "Menu";
                cntinue = "Continue";
                lvl = "Level";
                exitg = "Exit game";
                reklama = "Skip this level";
                mmenu = "Main Menu";
                lvlcmplt = "Level complete";
                break;
        }
        Menu.GetComponentInChildren<Text>().text = menu;
        Continue.GetComponentInChildren<Text>().text = cntinue;
        GetComponentInChildren<Text>().text = lvl + numberoflevel.ToString();
        ExitGame.GetComponentInChildren<Text>().text = exitg;
        text.text = reklama;
        MainMenu.GetComponentInChildren<Text>().text = mmenu;
        win.GetComponentInChildren<Text>().text = lvlcmplt;
        win.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text = cntinue;
    }
    void adok()
    {
        AdResultObj.SetActive(false);
        MenuDialog.SetActive(false);
    }
    void NextLevel()
    {
        if (ad >= 3)
        {
            Time.timeScale = 1.0f;
            PlayerPrefs.SetString("pause", "false");
            SceneManager.LoadScene(nextLevel);
        }
        else
        {
            Advertisement.Show("rewardedVideo");
            ad++;
        }
    }
    public void OnUnityAdsDidFinish(string placementId,ShowResult showResult)
    {
        Debug.Log(placementId);
        if (placementId == myPlacementId)
        {
            if (showResult == ShowResult.Finished)
            {
                while (ad < 4)
                {
                    Advertisement.Show(myPlacementId);
                    ad++;
                }
                switch (Application.systemLanguage)
                {
                    case SystemLanguage.Russian:
                        text.text = "Следующий уровень";
                        break;
                    case SystemLanguage.Ukrainian:
                        text.text = "Наступний рівень";
                        break;
                    default:
                        text.text = "Next Level";
                        break;
                }
            }
        }
        if(showResult == ShowResult.Skipped){}
        if(showResult == ShowResult.Failed)
        {
            AdResultObj.SetActive(true);
            switch (Application.systemLanguage)
            {
                case SystemLanguage.Russian:
                    AdResult.text = "Неизвестная ошибка";
                    break;
                case SystemLanguage.Ukrainian:
                    AdResult.text = "Невідома помилка";
                    break;
                default:
                    AdResult.text = "Unknown error";
                    break;
            }
        }
    }
    public void OnUnityAdsReady(string placementId){}
    public void OnUnityAdsDidError(string message) { Debug.Log(message); }
    public void OnUnityAdsDidStart(string placementId){}
    void Contn()
    {
        Time.timeScale = 1.0f;
        PlayerPrefs.SetString("pause", "false");
        MenuDialog.SetActive(false);
    }
    void ext()
    {
        Time.timeScale = 1.0f;
        PlayerPrefs.SetString("pause", "false");
        Application.Quit();
    }
    void Men()
    {
        Time.timeScale = 1.0f;
        PlayerPrefs.SetString("pause", "false");
        SceneManager.LoadScene("Menu");
    }

    void Nxt()
    {
    	if(Ad==true){
        Advertisement.Show();
        Debug.Log("AD Showed");
    	}
    	if(endOfChapter == true){
    		PlayerPrefs.SetInt("CHAPTER",NextChapter);
    	}
    	Time.timeScale = 1.0f;
        SceneManager.LoadScene(nextLevel);
    }
    void Mn()
    {
        MenuDialog.SetActive(true);
        Time.timeScale = 0.0f;
        PlayerPrefs.SetString("pause", "true");
    }
    // Update is called once per frame
    void Update()
    {
        NextLevelad.interactable = Advertisement.IsReady(myPlacementId);
        if(GameObject.Find("/player"))
            keyInInterface.SetActive(GameObject.Find("/player").GetComponent<controller>().haskey);
    }
}
