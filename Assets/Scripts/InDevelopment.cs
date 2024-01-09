using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class InDevelopment : MonoBehaviour
{
    public Button Back;
    public Button Support;
    // Startis called before the first frame update
    void Start()
    {
        Button bck = Back.GetComponent<Button>();
        bck.onClick.AddListener(back);
        Support.onClick.AddListener(sup);
    }
    void sup()
    {
        SceneManager.LoadScene("Support");
    }
    void back()
    {
        SceneManager.LoadScene("Menu");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
