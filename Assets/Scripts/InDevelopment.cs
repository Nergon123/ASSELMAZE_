using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class InDevelopment : MonoBehaviour
{
    public Button Back;
    // Startis called before the first frame update
    void Start()
    {
        Button bck = Back.GetComponent<Button>();
        bck.onClick.AddListener(back);
    }
    void back()
    {
        SceneManager.LoadScene("Menu");
    }
}
