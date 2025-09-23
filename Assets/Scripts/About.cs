using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class About : MonoBehaviour
{
    public Button BACK;
    // Start is called before the first frame update
    void Start()
    {
        Button Back = BACK.GetComponent<Button>();
        Back.onClick.AddListener(Return);
    }
    void Return()
    {
        SceneManager.LoadScene("Menu");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Return();
        }
    }
}
