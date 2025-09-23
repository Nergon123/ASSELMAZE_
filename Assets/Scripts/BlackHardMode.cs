using UnityEngine;
using UnityEngine.UI;

//Now it's seems to be a little bit racist.
//Back in 2020 when I was writing this I wasn't thinking about that...
public class BlackHardMode : MonoBehaviour
{
    Button but;
    Text text;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        but = GetComponent<Button>();
        text = GetComponent<Text>();
        but.onClick.AddListener(Pressed);
    }
    void Pressed()
    {
        text.fontSize = 70;
        count++;
        text.text = "Click " + (5 - count).ToString() + " times to Enable invisible skin";
        if (count >= 5)
        {
            text.text = "Hard (invisible) mode enabled!";
            PlayerPrefs.SetInt("skin", 100);
        }
    }
}
