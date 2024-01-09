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
        Back.onClick.AddListener(Bck);
    }
    void Bck()
    {
        SceneManager.LoadScene("Menu");
    }
    // Update is called once per frame
    void Update()
    {
        // Check if Back was pressed this frame
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            // Quit the application
            Bck();
        }
    }
}
