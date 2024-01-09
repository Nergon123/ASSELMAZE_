using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        text.text = "Click " + (5 - count).ToString() + " times to Enable black skin";
        if(count >= 5)
        {
            text.text = "Hard (black skin) mode enabled!";
            PlayerPrefs.SetInt("skin", 100);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
